﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using Common;
using System.Configuration;
using System.Text;
using Helper;
using System.IO;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;

namespace Book.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FileInfo fileinfo = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.xml"));
            //  log4net.Config.XmlConfigurator.Configure(fileinfo);
            #region .....
            //GrandDog Dog = MyDog.Dog;

            //uint RetCode = 1; 
            ////剩余验证次数
            //byte bDegree;

            //fixed (byte* productName1 = new byte[16])
            //{
            //    char[] arrayProductName = Dog.productName.ToCharArray(0, Dog.productName.Length);

            //    for (int i = 0; i < Dog.productName.Length; i++)
            //    {
            //        *(productName1 + i) = (byte)(arrayProductName[i]);
            //    }
            //    *(productName1 + Dog.productName.Length) = 0;

            //    uint handle = Dog.ulDogHandle;

            //    RetCode = Dog.OpenDog(1, productName1, &handle);

            //    Dog.ulDogHandle = handle;
            //}

            //if (RetCode != 0)
            //{
            //    System.Windows.Forms.MessageBox.Show("请插入加密狗运行程序！");
            //    Application.Exit();
            //    return;
            //}

            //RetCode = Dog.VerifyPassword(Dog.ulDogHandle, Common.GrandDog.RC_PASSWORDTYPE_USER, Dog.userPassWord, &bDegree);

            //if (RetCode != 0)
            //{
            //    // failed
            //    //if (bPasswordType == 1)
            //    //{

            //    //}
            //    //if (RetCode == E_RC_VERIFY_PASSWORD_FAILED)
            //    //{
            //    //    ResultBox.AppendText("The verify count left is:");
            //    //    ResultBox.AppendText(Convert.ToString(bDegree));
            //    //}
            //    Application.Exit();
            //    return;
            //}

            //RetCode = Dog.CheckDog(Dog.ulDogHandle);
            //if (RetCode != 0)
            //{
            //    // failed
            //    Application.Exit();
            //    return;
            //}

            //RetCode = Dog.VisitLicenseFile(Dog.ulDogHandle, Dog.usDirID, Dog.usFileID, 0);
            //if (RetCode != 0)
            //{
            //    string str = Convert.ToString(RetCode, 16).ToUpper();
            //    switch (str)
            //    {
            //        //使用次数为0
            //        case "A816001A":
            //            MessageBox.Show("许可证的使用次数为0，许可证已失效！");
            //            break;
            //        //有效运行时间小于三分钟
            //        case "A816001B":
            //            MessageBox.Show("已经到达许可证运行累计时间，许可证已失效！");
            //            break;
            //        //许可证已过期
            //        case "A816001C":
            //            MessageBox.Show("许可证时间不在有效期内，许可证已失效！");
            //            break;
            //        //系统时间被篡改
            //        case "A816001D":
            //            MessageBox.Show("系统时间被篡改，许可证已失效！");
            //            break;
            //        default:
            //            break;
            //    }
            //    Application.Exit();
            //    return;
            //}
            #endregion
            if (ConfigurationManager.AppSettings["Languages"] == "0")
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-TW");
            else if (ConfigurationManager.AppSettings["Languages"] == "1")
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            else
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("EN");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged();

            //选择连接：默认连接主机1，主机1连不到连主机2

            //string file = "";          用ping的方式开启项目时会ping地址，耗时太长，导致双击程序半天才打开。
            //try
            //{
            //    Ping ping = new Ping();
            //    PingReply pr = ping.Send("221.222.222.7");
            //    if (pr != null)
            //    {
            //        if (pr.Status == IPStatus.Success)
            //            file = "connections.xml";
            //        else
            //            file = "connections2.xml";
            //    }
            //    else
            //        file = "connections2.xml";
            //}
            //catch
            //{
            //    file = "connections.xml";
            //}
            string file = "connections.xml";
            if (!System.IO.File.Exists(file))
            {
                MessageBox.Show(Properties.Resources.NoConfigConnectionFirstConfigConection);
                return;
            }

            IList<Common.Connection> connections;
            //IList<Common.Connection> connections2 = new List<Common.Connection>();
            try
            {
                connections = Common.ConnectionInfoAccessor.Load(file);

                if (!connections[0].Awailable)
                {
                    file = "connections2.xml";
                    if (System.IO.File.Exists(file))
                        connections = Common.ConnectionInfoAccessor.Load(file);
                }


            }
            catch
            {
                MessageBox.Show(Properties.Resources.ReadConfigInfoError);
                return;
            }

            //设置皮肤
            String configFile = Application.ExecutablePath + ".config";
            XmlDocument document = new XmlDocument();
            document.Load(configFile);

            XmlNodeList nodes = document.SelectNodes("/configuration/userSettings/Book.UI.Properties.Settings/setting");
            foreach (XmlNode node in nodes)
            {
                if (node.Attributes["name"].Value == "Skin")
                {
                    General.LoginForm f = new General.LoginForm();
                    f.defaultLookAndFeel1.LookAndFeel.SkinName = node.FirstChild.InnerText;
                }
            }

            //Application.ThreadExit += new EventHandler(Application_ThreadExit);
            // 0423注释，取消连接数据库窗口
            Book.UI.General.LoginForm loginForm = new Book.UI.General.LoginForm(connections);
            if (loginForm.ShowDialog() != DialogResult.OK)
                return;


            // Application.ThreadExit += new EventHandler(Application_ThreadExit);
            //loginForm = new Book.UI.General.LoginForm(connections);
            //if (loginForm.ShowDialog() != DialogResult.OK)
            //    return;
            //string s = BL.Settings.CompanyPhone;


            //System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            //Form from = (Form)assembly.CreateInstance(loginForm.CurrentModule.ClassName);



            //使用ModifyConfigurations() 方法调用
            //  ModifyConfigurations(loginForm.SelectedConnection);
            //  activeConnection = loginForm.SelectedConnection;







            // 加载用户对本套系统的使用期限
            // 如果使用期低于某个值，则提醒用户注册；

            // 之后再次检测使用期限，如果使用期限已过，则退出程序

            if (DateTime.Now.CompareTo(Helper.DateTimeParse.InvalidDate) > 0)
            {
                MessageBox.Show(Properties.Resources.GuoQiTiXing, Properties.Resources.TiShi, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



            //if (!Validate())
            //    return;


            // 登录

            Application.ThreadExit += new EventHandler(Application_ThreadExit);

            //General.LoginForm loginForm1 = new Book.UI.General.LoginForm();
            //if (loginForm.ShowDialog() != DialogResult.OK)
            //    return;
            BL.V.ActiveOperator = loginForm.Operator;
            BL.V.RoleList = new BL.RoleManager().Select(BL.V.ActiveOperator.OperatorsId);
            BL.V.SetDataFormat = new BL.SetDataFormatManager().GetData();
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Form from = (Form)assembly.CreateInstance(loginForm.CurrentModule.ClassName);
            Application.Run(from);
        }

        #region .....

        //public   static void ModifyConfigurations()
        //{
        //    ModifyConfigurations(loginForm.SelectedConnection);
        //    activeConnection = loginForm.SelectedConnection;        

        //}
        static void Application_ThreadExit(object sender, EventArgs e)
        {
            if (flag)
                return;
            String configFile = Application.ExecutablePath + ".config";
            XmlDocument document = new XmlDocument();
            document.Load(configFile);

            XmlNodeList nodes = document.SelectNodes("/configuration/userSettings/Book.UI.Properties.Settings/setting");
            foreach (XmlNode node in nodes)
            {
                if (node.Attributes["name"].Value == "LastTime")
                {
                    node.FirstChild.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                if (node.Attributes["name"].Value == "Skin")
                {
                    General.LoginForm f = new General.LoginForm();
                    f.defaultLookAndFeel1.LookAndFeel.SkinName = node.FirstChild.InnerText;
                }
            }
            document.Save(configFile);





        }

        //時間是否被修改
        static bool flag = false;

        static bool Validate()
        {
            bool returnValue = true;
            String configFile = Application.ExecutablePath + ".config";
            XmlDocument document = new XmlDocument();
            document.Load(configFile);

            XmlNodeList nodes = document.SelectNodes("/configuration/userSettings/Book.UI.Properties.Settings/setting");
            foreach (XmlNode node in nodes)
            {
                if (node.Attributes["name"].Value == "LastTime")
                {
                    string text = node.FirstChild.InnerText;
                    if (!string.IsNullOrEmpty(text))
                    {
                        DateTime lasttime = DateTime.Parse(text);
                        if (DateTime.Now.CompareTo(lasttime) < 0)
                        {
                            //系统时间被修改       
                            flag = true;
                            MessageBox.Show(Properties.Resources.SystemDateChanged, Properties.Resources.TiShi, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            returnValue = false;
                        }
                        else
                        {
                            if (DateTime.Now.CompareTo(Helper.DateTimeParse.InvalidDate) > 0)
                            {
                                MessageBox.Show(Properties.Resources.GuoQiTiXing, Properties.Resources.TiShi, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                returnValue = false;
                            }
                        }
                    }
                }
                if (string.IsNullOrEmpty(Url))
                {
                    if (node.Attributes["Name"].Value == "Url")
                    {
                        Url = node.FirstChild.InnerText;
                    }
                }
            }
            document.Save(configFile);
            return returnValue;
        }

        private static string Url = string.Empty;

        public static void ModifyConfigurations(Common.Connection connection)
        {


            //String configFile = Application.ExecutablePath + ".config";
            //XmlDocument document = new XmlDocument();
            //document.Load(configFile);

            //XmlNodeList nodes = document.SelectNodes("/configuration/userSettings/Book.UI.Properties.Settings/setting");
            //foreach (XmlNode node in nodes)
            //{
            //    if (node.Attributes["name"].Value == "accessorImplementionsLocation")
            //        node.FirstChild.InnerText = "Book.DA." + connection.Type;
            //}
            //document.Save(configFile);


            System.Configuration.Configuration cfa = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            KeyValueConfigurationElement accessorImplementionsLocation = cfa.AppSettings.Settings["accessorImplementionsLocation"];


            if (accessorImplementionsLocation == null)
            {
                cfa.AppSettings.Settings.Add("accessorImplementionsLocation", string.Format("Book.DA.{0}", connection.Type));
            }
            else
            {
                cfa.AppSettings.Settings["accessorImplementionsLocation"].Value = string.Format("Book.DA.{0}", connection.Type);
            }
            cfa.Save();


            XmlDocument document1 = new XmlDocument();

            String configFile = string.Format("Book.{0}.SQLMap.config", connection.Type);
            document1.Load(configFile);
            XmlNamespaceManager nm = new XmlNamespaceManager(document1.NameTable);
            nm.AddNamespace("aa", "http://ibatis.apache.org/dataMapper");

            XmlNode datasourceNode = document1.SelectSingleNode("/aa:sqlMapConfig/aa:database/aa:dataSource", nm);
            if (datasourceNode != null)
            {
                datasourceNode.Attributes["connectionString"].Value = connection.ToString("r");
            }

            document1.Save(configFile);



        }

        private static Common.Connection activeConnection;
        public static Common.Connection ActiveConnection
        {
            get
            {
                return activeConnection;
            }
        }

        #endregion
    }
}