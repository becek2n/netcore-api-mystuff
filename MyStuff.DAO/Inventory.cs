using System;
using System.Linq;
using MyStuff.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStuff.DAO
{
    public class Inventories
    {
        private mystuffdbContext context = new mystuffdbContext();
        public async Task<ResultModel<List<Inventory>>> Get() {
            ResultModel<List<Inventory>> resultModel = new ResultModel<List<Inventory>>();
            try
            {
                var data = await context.Inventories
                    .Include(x => x.InventoryImages)
                    .ToListAsync();

                resultModel.SetSuccess("success", data);

            }
            catch (Exception ex)
            {
                resultModel.SetFailed("Inventories.GetInventory: " + ex.Message);
            }

            return resultModel;
        }

        public ResultModel<List<Inventory>> GetById(int id)
        {
            ResultModel<List<Inventory>> resultModel = new ResultModel<List<Inventory>>();
            try
            {
                var ctx = new mystuffdbContext();
                var data = context.Inventories
                    .Where(x => x.Id == id)
                    .Include(x => x.InventoryImages)
                    .ToList();

                resultModel.SetSuccess("success", data);

            }
            catch (Exception ex)
            {
                resultModel.SetFailed("Inventories.GetInventory: " + ex.Message);
            }

            return resultModel;
        }

        public async Task<ResultModel<object>> Save(Inventory inventory)
        {
            ResultModel<object> resultModel = new ResultModel<object>();
            try
            {
                context.Entry(inventory).State = EntityState.Added;
                await context.SaveChangesAsync();

                resultModel.SetSuccess("success");
            }
            catch (Exception ex)
            {
                resultModel.SetFailed("Inventories.Save : " + ex.Message);
            }
            return resultModel;
        }

        public async Task<ResultModel<object>> Update(Inventory inventory)
        {
            ResultModel<object> resultModel = new ResultModel<object>();
            try
            {
                context.Entry(inventory).State = EntityState.Modified;
                await context.SaveChangesAsync();

                resultModel.SetSuccess("success");

            }
            catch (Exception ex)
            {
                resultModel.SetFailed("Inventories.Update : " + ex.Message);
            }
            return resultModel;
        }

        public async Task<ResultModel<object>> Delete(int id)
        {
            ResultModel<object> resultModel = new ResultModel<object>();
            try
            {
                var inventory = await context.Inventories.FindAsync(id);
                if (inventory == null)
                {
                    resultModel.SetFailed("Not Found!");
                }

                context.Inventories.Remove(inventory);
                await context.SaveChangesAsync();

                resultModel.SetSuccess("success");
            }
            catch (Exception ex)
            {
                resultModel.SetFailed("Inventories.Delete: " + ex.Message);
            }
            return resultModel;
        }
    }
}
