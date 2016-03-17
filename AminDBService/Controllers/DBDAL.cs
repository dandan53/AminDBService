using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AminDBService.Models;

namespace AminDBService.Controllers
{
    public class DBDAL
    {
        private AminDBServiceContext context = new AminDBServiceContext();

        private static DBDAL instance = null;

        private DBDAL()
        {
        }

        public static DBDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBDAL();

                    //Init();
                }
                return instance;
            }
        }

        public List<string> GetPersonList(string type)
        {
            return (from member in context.Members where member.Type.Equals(type) select member.Name).ToList();
        }

        public bool AddPerson(string person, string type)
        {
            if (IsPersonExist(person, type) == false)
            {
                var newMember = new Member() {Name = person};
                context.Members.Add(newMember);
                context.SaveChanges();
            }

            return true;
        }

        public void RemovePerson(string person, string type)
        {
            if (IsPersonExist(person, type))
            {
                Member member = context.Members.Single(x => x.Name.Equals(person) && x.Type.Equals(type));
                context.Members.Remove(member);
                context.SaveChanges();
            }
        }

        public bool IsPersonExist(string person, string type)
        {
            var members = context.Members.ToList();
            var retVal = members.Exists(x => x.Name.Equals(person) && x.Type.Equals(type));
            return retVal;
        }
        

        //private int CreateMemberId()
        //{
        //    var maxMemberId = context.Members.ToList().Max(x => x.MemberId);

        //    return ++maxMemberId;
        //}

    }
}