using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Online_Bill_Management_Systm.Models;

namespace Online_Bill_Management_Systm.Controllers
{
    public class BILLCrudController : ApiController
    {
        BILLEntities bill = new BILLEntities();
        public IHttpActionResult getBILL()
        {
            
            var result = bill.BILLs.ToList();
            return Ok(result);
        }

        public IHttpActionResult BILLinsert(BILL BILLinsert)
        {
            bill.BILLs.Add(BILLinsert);
            bill.SaveChanges();
            return Ok();
        }

        public IHttpActionResult GetBILLID(int id)
        {
            BILLClass BILLDetails = null;
            BILLDetails = bill.BILLs.Where(x => x.BILLID == id).Select(x => new BILLClass()
            {
                BILLID = x.BILLID,
                SHOPNAME = x.SHOPNAME,
                ADDRESS = x.ADDRESS,
                DATE = x.DATE,
                AMOUNT = x.AMOUNT,
                ITEM = x.ITEM
            }).FirstOrDefault<BILLClass>();
            if (BILLDetails == null)
            {
                return NotFound();
            }
            return Ok(BILLDetails);
        }

        public IHttpActionResult Put(BILLClass bc)
        { 
            var updateBILL = bill.BILLs.Where(x => x.BILLID == bc.BILLID).FirstOrDefault<BILL>();
            if(updateBILL!=null)
            {
                updateBILL.BILLID = bc.BILLID;
                updateBILL.SHOPNAME = bc.SHOPNAME;
                updateBILL.ADDRESS = bc.ADDRESS;
                updateBILL.DATE = bc.DATE;
                updateBILL.AMOUNT = bc.AMOUNT;
                updateBILL.ITEM = bc.ITEM;
                bill.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var BILLdel = bill.BILLs.Where(x => x.BILLID == id).FirstOrDefault();
            bill.Entry(BILLdel).State = System.Data.Entity.EntityState.Deleted;
            bill.SaveChanges();
            return Ok();
        }
    }
}
