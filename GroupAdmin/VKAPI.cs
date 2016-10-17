using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Threading;
using System.Collections;


namespace GroupAdmin
{
    class VKAPI
    {
        public string AccessToken = "";

        public VKAPI(string accessToken)
        { 
            this.AccessToken = accessToken ;
                
        }
        
        

        private XmlDocument ExecuteCommand(string name, NameValueCollection qs)
        {
          
            XmlDocument result = new XmlDocument() ;
            int ret = 0;
            result.Load(String.Format("https://api.vkontakte.ru/method/{0}.xml?access_token={1}&{2}", name, this.AccessToken, String.Join("&", from item in qs.AllKeys select item + "=" + qs[item])));
            foreach (XmlNode node in result.SelectNodes("/error/error_code"))
            {
                // MessageBox.Show(node.InnerText.ToString());
                ret = Convert.ToInt32(node.InnerText.ToString());
                
            }
            return result;
            
        }

        public void Capcha_start (object Params)
        {
            var form = ((FormCapcha)((object[])Params)[0]);
                    form.Tag = "stop";

                    while (form.Tag.ToString() == "stop") //ждем пока пользователь не нажмет кнопку
                    {
                        form.Invoke(new Action(() =>
                        {

                            form.Show();
                            //form.webBrowser1.Navigate ((ParArr)[1].ToString ());
                            form.label1.Text = ((object[])Params)[1].ToString(); //передаем в форму переменную
                        }));

                    }
        }


        public XmlDocument GetGroupMembers(int groupID)
        {
            NameValueCollection qs = new NameValueCollection();
            qs["group_id"] = groupID.ToString();
            
            return ExecuteCommand("groups.getMembers", qs);
        }
        public XmlDocument GetGroupMembers(string groupID, string offset)
        {
            NameValueCollection qs = new NameValueCollection();
            qs["group_id"] = groupID.ToString();
            qs["offset"] = offset.ToString();
            XmlDocument friendList = ExecuteCommand("groups.getMembers", qs);

            return friendList;
        }

        public XmlDocument InviteUserToGroup(int groupID, int userID)
        {
            NameValueCollection qs = new NameValueCollection();
            qs["group_id"] = groupID.ToString();
            qs["user_id"] = userID.ToString ();
            return ExecuteCommand("groups.invite", qs);
        }

        public XmlDocument InviteUserToGroup(int groupID, int userID, string sid, string key)
        {
            NameValueCollection qs = new NameValueCollection();
            qs["group_id"] = groupID.ToString();
            qs["user_id"] = userID.ToString();
            qs["captcha_sid"] = sid;
            qs["captcha_key"] = key;

            return ExecuteCommand("groups.invite", qs);
        }

        public int InviteUserToGroup(int groupID, int userID, bool t)
        {
            NameValueCollection qs = new NameValueCollection();
            int ret = 0;
            qs["group_id"] = groupID.ToString();
            qs["user_id"] = userID.ToString();
            XmlDocument retlist = ExecuteCommand("groups.invite", qs);
            foreach (XmlNode node in retlist.SelectNodes("/error/error_code"))
            {
                // MessageBox.Show(node.InnerText.ToString());
                ret = Convert.ToInt32(node.InnerText.ToString());
                if (ret != 0)
                {
                    MessageBox.Show(ret.ToString() + " - " + userID);
                
         
                }
            }
            // XmlNodeList singlnode = retlist.SelectNodes("/error/error_code");

            return 0;
        }


        public XmlDocument InviteAllFriendsInGroup(object Params) //friends.get
        {
            NameValueCollection qs = new NameValueCollection();
            XmlDocument friendList = ExecuteCommand("friends.get", qs);


            return friendList;

        }

        public XmlDocument GetAllFriends( ) //friends.get
        {
            NameValueCollection qs = new NameValueCollection();
            XmlDocument friendList = ExecuteCommand("friends.get", qs);

            return friendList;

        }
        public XmlDocument SetOffline() //account.setOffline
        {
            NameValueCollection qs = new NameValueCollection();
            XmlDocument SetOffline = ExecuteCommand("account.setOffline", qs);

            return SetOffline;

        }

        public XmlDocument GetMessages(string mestype) //messages.get
        {
            NameValueCollection qs = new NameValueCollection();
            qs["out"] = mestype;
            XmlDocument GetMessages = ExecuteCommand("messages.get", qs);
            return GetMessages;
        }
        public XmlDocument GetUserInfo(int uid, string fields) //users.get
        {
            NameValueCollection qs = new NameValueCollection();
            qs["user_ids"] = uid.ToString ();
            qs["fields"] = fields;
            XmlDocument GetMessages = ExecuteCommand("users.get", qs);

            return GetMessages;
        }
        public XmlDocument SendMessage(string uid, string message, string title) //messages.send
        {
            NameValueCollection qs = new NameValueCollection();
            qs["user_id"] = uid;
            qs["message"] = message;
            qs["title"] = title;

            XmlDocument GetMessages = ExecuteCommand("messages.send", qs);

            return GetMessages;
        }

        public XmlDocument SendMessage(string uid, string message, string title, string sid, string key) //messages.send
        {
            NameValueCollection qs = new NameValueCollection();
            qs["user_id"] = uid;
            qs["message"] = message;
            qs["title"] = title;
            qs["captcha_sid"] = sid;
            qs["captcha_key"] = key;

            XmlDocument GetMessages = ExecuteCommand("messages.send", qs);

            return GetMessages;
        }


        public XmlDocument WallPost(string ownerid, string message, string attachments) //Wall.post
        {
            NameValueCollection qs = new NameValueCollection();
            qs["owner_id"] = ownerid;
            qs["message"] = message;
            qs["attachments"] = attachments;
            

            XmlDocument returnn = ExecuteCommand("wall.post", qs);

            return returnn;
        }
        public XmlDocument WallPost(string ownerid, string message, string attachments, string sid, string key)
        {
            NameValueCollection qs = new NameValueCollection();
            qs["owner_id"] = ownerid;
            qs["message"] = message;
            qs["attachments"] = attachments;
            qs["captcha_sid"] = sid;
            qs["captcha_key"] = key;

            return ExecuteCommand("wall.post", qs);
        }
        public string GetGroupID(string ids) //group.getbyid
        {
            NameValueCollection qs = new NameValueCollection();
            qs["group_ids"] = ids;

            XmlDocument returnn = ExecuteCommand("groups.getById", qs);


            string ret = returnn.SelectSingleNode("/response/group/gid").InnerText.ToString(); 
            return ret;
        }

        public XmlDocument WallRepost(string objct, string message, string groupid, string reff, string sid, string key)
        {
            NameValueCollection qs = new NameValueCollection();
            qs["object"] = objct;
            qs["message"] = message;
            qs["group_id"] = groupid;
            qs["ref"] = reff;
            qs["captcha_sid"] = sid;
            qs["captcha_key"] = key;

            return ExecuteCommand("wall.repost", qs);
        }

        public XmlDocument GetRequests()
        {
            NameValueCollection qs = new NameValueCollection();
            qs["offset"] = "0";
            qs["out"] = "0";

            return ExecuteCommand("friends.getRequests", qs);
        }
        public XmlDocument AddFriend(string id )
        {
            NameValueCollection qs = new NameValueCollection();
            qs["user_id"] = id;
            
            return ExecuteCommand("friends.add", qs);
        }

    }


}
