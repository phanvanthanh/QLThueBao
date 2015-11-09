//using System;
//using System.Data;
//using System.Data.EntityClient;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;


//public partial class Procedures : global::System.Data.Objects.ObjectContext
//{
//    public void CreateTables()
//    {
//        try
//        {
//            this.Connection.Open();
//            EntityCommand command = new EntityCommand();
//            //Imported function name
//            command.CommandText = "QLThuebaoEntities.CreateTable";
//            command.CommandType = CommandType.StoredProcedure;
//            // EntityParameter param1 = new EntityParameter("storeId", DbType.String, 4);
//            // param1.Value = storeId;
//            //EntityParameter param2 = new EntityParameter("state", DbType.String, 2);
//            //param2.Value = State;
//            //command.Parameters.Add(param1);
//            //command.Parameters.Add(param2);
//            command.Connection = this.Connection as EntityConnection;
//            command.ExecuteNonQuery();
//        }
//        catch (Exception ex)
//        {
//        }
//    }

//}