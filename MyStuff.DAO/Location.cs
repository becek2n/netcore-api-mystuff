using System;
using MyStuff.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStuff.DAO
{
    public class Locations
    {
        private mystuffdbContext context = new mystuffdbContext();
        public async Task<ResultModel<List<Location>>> GetLocation() {
            ResultModel<List<Location>> resultModel = new ResultModel<List<Location>>();
            try
            {
                var data = await context.Locations.ToListAsync();

                resultModel.SetSuccess("success", data);

            }
            catch (Exception ex)
            {
                resultModel.SetFailed("Locations.GetLocation: " + ex.Message);
            }

            return resultModel;
        }

        public async Task<ResultModel<object>> Save(Location location)
        {
            ResultModel<object> resultModel = new ResultModel<object>();
            try
            {
                context.Entry(location).State = EntityState.Added;
                await context.SaveChangesAsync();

                resultModel.SetSuccess("success");
            }
            catch (Exception ex)
            {
                resultModel.SetFailed("Locations.Save : " + ex.Message);
            }
            return resultModel;
        }

        public async Task<ResultModel<object>> Update(Location location)
        {
            ResultModel<object> resultModel = new ResultModel<object>();
            try
            {
                context.Entry(location).State = EntityState.Modified;
                await context.SaveChangesAsync();

                resultModel.SetSuccess("success");

            }
            catch (Exception ex)
            {
                resultModel.SetFailed("Locations.Update : " + ex.Message);
            }
            return resultModel;
        }

        public async Task<ResultModel<object>> Delete(int id)
        {
            ResultModel<object> resultModel = new ResultModel<object>();
            try
            {
                var location = await context.Locations.FindAsync(id);
                if (location == null)
                {
                    resultModel.SetFailed("Not Found!");
                }

                context.Locations.Remove(location);
                await context.SaveChangesAsync();

                resultModel.SetSuccess("success");
            }
            catch (Exception ex)
            {
                resultModel.SetFailed("Locations.Delete: " + ex.Message);
            }
            return resultModel;
        }
    }
}
