using prj認真版嗎.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.ViewModel
{
    public class CAdminViewModel
    {
        public CAdminViewModel()
        {
            _admin = new Admin();
        }
        private Admin _admin;

        public Admin admin
        {
            get { return _admin; }
            set { _admin = value; }
        }

        [DisplayName("ID")]
        public int AdminId
        {
            get { return _admin.AdminId; }
            set { _admin.AdminId = value; }
        }
        [DisplayName("權限名")]
        public string AdminName
        {
            get { return _admin.AdminName; }
            set { _admin.AdminName = value; }
        }
        [DisplayName("帳號")]
        public string Account
        {
            get { return _admin.Account; }
            set { _admin.Account = value; }
        }
        [DisplayName("密碼")]
        public string Password
        {
            get { return _admin.Password; }
            set { _admin.Password = value; }
        }
        [DisplayName("評論權限")]
        public bool CommentStatus { get; set; }
        [DisplayName("商品權限")]
        public bool ProductStatus { get; set; }
        [DisplayName("會員權限")]
        public bool MemberStatus { get; set; }
        [DisplayName("管理員權限")]
        public bool AdminStatus1 { get; set; }
    }
}
