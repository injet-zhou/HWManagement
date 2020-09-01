using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW.Models
{
    public class PostModel
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string ToChange { get; set; }
        public PostModel(string id,string type,string change)
        {
            Id = id;
            Type = type;
            ToChange = change;
        }
    }
    public class StudentAddModel
    {
        public string OpenId { get; set; }
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string Sclass { get; set; }
        public string Phone { get; set; }
        public string School { get; set; }
        public string Avatar { get; set; }
        public string Pwd { get; set; }
        public StudentAddModel(string openId,string studentId,string name,string sclass,string avatar,string pwd)
        {
            OpenId = openId;
            StudentId = studentId;
            Name = name;
            Sclass = sclass;
            Avatar = avatar;
            Pwd = pwd;
        }
        /*public StudentAddModel(string openId, string studentId, string name, string phone, string school, string sclass, string avatar, string pwd)
        {
            OpenId = openId;
            StudentId = studentId;
            Name = name;
            Phone = phone;
            School = school;
            Sclass = sclass;
            Avatar = avatar;
            Pwd = pwd;
        }*/
    }
    public class ResponseModel
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public ResponseModel(int code,string msg)
        {
            Code = code;
            Msg = msg;
        }
    }

}
