﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.UI;
using AminDBService.Models;

namespace AminDBService.Controllers
{
    public class DAL
    {
        private const string REFUA = "refua";

        private const string ILUI = "ilui";
        
        private List<string> iluiPersonList;

        private List<string> refuaPersonList;

        private static DAL instance = null;

        private DAL()
        {
        }

        public static DAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL();
                }
                return instance;
            }
        }

        public List<string> GetPersonList(string type)
        {
            List<string> retVal = null;

            if (type.Equals(REFUA))
            {
                retVal = refuaPersonList;
            }
            else if (type.Equals(ILUI))
            {
                retVal = iluiPersonList;
            }

            return retVal;
        }

        public bool AddPerson(string person, string type)
        {
            if (IsPersonExist(person, type) == false)
            {
                if (type.Equals(REFUA))
                {
                    refuaPersonList.Add(person);
                }
                else if (type.Equals(ILUI))
                {
                    iluiPersonList.Add(person);
                }
                
                DBDAL.Instance.AddPerson(person, type);
            }

            return true;
        }

        public bool IsPersonExist(string person, string type)
        {
            bool retVal = false;

            if (type.Equals(REFUA))
            {
                retVal = refuaPersonList.Exists(item => item.Equals(person));
            }
            else if (type.Equals(ILUI))
            {
                retVal = iluiPersonList.Exists(item => item.Equals(person));
            }
                
            return retVal;
        }

        public void Init()
        {
            iluiPersonList = DBDAL.Instance.GetPersonList(ILUI);
            refuaPersonList = DBDAL.Instance.GetPersonList(REFUA);
        }

    }
}