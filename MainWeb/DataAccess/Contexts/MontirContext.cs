﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MainWeb.DataAccess.Dto;
using MainWeb.Models;

namespace MainWeb.DataAccess.Contexts
{
    public class MontirContext : IDataContext<Montir>
    {
        public bool Delete(int Id)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    if (db.Montir.Delete(x => x.IdMontir == Id))
                        return true;
                    throw new SystemException("Data Tidak terhapus");
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        internal IEnumerable<MontirServiceModel> GetByIdWithDetail(int id)
        {
            using (var db = new OcphDbContext())
            {
                var result = from service in db.Services.Where(x => x.IdMontir == id)
                             join penjualan in db.Penjualan.Select() on service.IdPenjualan equals penjualan.IdPenjualan
                             select new ItemServiceDto
                             {
                                 Biaya = service.Biaya,
                                 IdItem = service.IdItem,
                                 IdMontir = service.IdMontir,
                                 IdPenjualan = service.IdPenjualan,
                                 Keterangan = service.Keterangan,
                                 Perbaikan = service.Perbaikan,
                                 Tanggal = penjualan.TanggalJual,
                                 NoFaktur = penjualan.FakturPenjualan
                             };

                var datas= MapperData.Map<List<ItemService>>(result.ToList());

                var list = new List<MontirServiceModel>();
                foreach(var item in datas.GroupBy(x => x.NoFaktur))
                {
                    list.Add(new MontirServiceModel(item));
                }

                return list;
            }
        }

        public IEnumerable<Montir> Get()
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var result = db.Montir.Select().ToList();
                    return MapperData.Map<IEnumerable<Montir>>(result);
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public Montir GetById(int Id)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var result = db.Montir.Where(x=>x.IdMontir==Id).FirstOrDefault();
                    return MapperData.Map<Montir>(result);
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public Montir Insert(Montir item)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    item.IdMontir = db.Montir.InsertAndGetLastID(MapperData.Map<MontirDto>(item));
                    if (item.IdMontir > 0)
                        return item;
                    throw new SystemException("Data Tidak Tersimpan");
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public Montir Update(Montir item, int Id)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var dto = MapperData.Map<MontirDto>(item);
                    if (db.Montir.Update(x=>new { x.Alamat,x.NamaMontir,x.NoTelpon},dto,x=>x.IdMontir==Id))
                    {
                        item.IdMontir = Id;
                        return item;
                    }
                    throw new SystemException("Data Tidak Tersimpan");
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }
    }
}