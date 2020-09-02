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
    public class TeacherAddModel
    {
        public string OpenId { get; set; }
        public string TeacherId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string School { get; set; }
        public string Avatar { get; set; }
        public string Pwd { get; set; }
        public TeacherAddModel(string openId, string teacherId, string name, string avatar, string pwd)
        {
            OpenId = openId;
            TeacherId = teacherId;
            Name = name;
            Avatar = avatar;
            Pwd = pwd;
        }
    }
    public class HomeworkAddModel
    {
        public string HomeworkId { get; set; }
        public string CourseId { get; set; }
        public string Name { get; set; }
        public DateTime? Due { get; set; }
        public DateTime? Created { get; set; }
        public int? Published { get; set; }
        public int? Mulsubmit { get; set; }
        public string Content { get; set; }
        public HomeworkAddModel(string courseId,string name,DateTime due,int pub,int mul,string content)
        {
            CourseId = courseId;
            Name = name;
            Due = due;
            Published = pub;
            Mulsubmit = mul;
            Content = content;
        }
    }
    public class CourseAddModel
    {
        public string CourseId { get; set; }
        public string OpenId { get; set; }
        public string Name { get; set; }
        public string Intro { get; set; }
        public CourseAddModel(string openId,string name,string intro)
        {
            OpenId = openId;
            Name = name;
            Intro = intro;
        }
    }
    public class EnrollmentAddModel
    {
        public string EnrollmentId { get; set; }
        public string OpenId { get; set; }
        public string CourseId { get; set; }
        public int? Score { get; set; }
        public EnrollmentAddModel(string openId,string courseId)
        {
            OpenId = openId;
            CourseId = courseId;
        }
    }
    public class ResourceAddModel
    {
        public string ResourceId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public int? Size { get; set; }
        public ResourceAddModel(string name,string url,string type,int size)
        {
            Name = name;
            Url = url;
            Type = type;
            Size = size;
        }
    }

}
