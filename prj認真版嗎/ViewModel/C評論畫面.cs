using prj認真版嗎.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.ViewModel
{
    public class C評論畫面
    {
        public C評論畫面()
        {
            _com = new Comment();
        }
        private Comment _com;

        public Comment comment
        {
            get { return _com; }
            set { _com = value; }
        }
        [DisplayName("評價編號")]
        public int CommentId
        {
            get { return _com.CommentId; }
            set { _com.CommentId = value; }
        }
        [DisplayName("會員編號")]
        public int MembersId
        {
            get { return _com.MembersId; }
            set { _com.MembersId = value; }
        }
        [DisplayName("產品編號")]
        public int TravelProductId
        {
            get { return _com.TravelProductId; }
            set { _com.TravelProductId = value; }
        }
        [DisplayName("評價內容")]
        public string CommentText
        {
            get { return _com.CommentText; }
            set { _com.CommentText = value; }
        }
        [DisplayName("星數")]
        public int Star
        {
            get { return _com.Star; }
            set { _com.Star = value; }
        }
        [DisplayName("評價時間")]
        public string CommentDate
        {
            get { return _com.CommentDate; }
            set { _com.CommentDate = value; }
        }
         
        public string 產品名稱 { get; set; }
        public string 會員名稱 { get; set; }
    }
}
