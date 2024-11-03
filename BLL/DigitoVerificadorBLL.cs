﻿using BE;
using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DigitoVerificadorBLL
    {
        DigitoVerificadorDAL dal;

        public DigitoVerificadorBLL()
        {
            dal = new DigitoVerificadorDAL();
        }
        
        public static void Update(string tableName)
        {
            new DigitoVerificadorDAL().Update(tableName);
        }

        public void RecalculateDVs(List<DigitoVerificadorBE> list)
        {
            foreach (DigitoVerificadorBE dv in list)
            {
                dal.Update(dv);
            }
            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.DigitoVerificador, Operacion.RecalcularDVs));
        }

        public void RecalculateAllDVs()
        {
            dal.RecalculateAllDVs();
        }

        public void VerifyDV(string username)
        {
            if (!dal.CompareDV())
            {
                UsuarioBLL userBLL = new UsuarioBLL();
                if (userBLL.IsAdmin(username))
                    throw new DVException(DVErrorType.Admin);
                throw new DVException(DVErrorType.NoAdmin);
            }
        }

        public List<DigitoVerificadorBE> GetCalculatedDVs()
        {
            return dal.calculatedDVs;
        }
    }
}
