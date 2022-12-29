using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PaymentService
    {
        public static PaymentDTO Add(PaymentDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<PaymentDTO, Payment>();
                c.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Payment>(data);
            var ret = DataAccessFactory.PaymentDataAccess().Add(dbobj);
            return mapper.Map<PaymentDTO>(ret);
        }

        public static List<PaymentDTO> Get()
        {
            var data = DataAccessFactory.PaymentDataAccess().Get();
            var config = new MapperConfiguration(c => {
                c.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<PaymentDTO>>(data);
        }

        public static PaymentDTO Get(int id)
        {
            var data = DataAccessFactory.PaymentDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(config);
            var Payment = mapper.Map<PaymentDTO>(data);
            return Payment;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.PaymentDataAccess().Delete(id);
        }

        public static PaymentDTO Update(PaymentDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Payment, PaymentDTO>();
                c.CreateMap<PaymentDTO, Payment>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Payment>(obj);
            var data = DataAccessFactory.PaymentDataAccess().Update(newobj);
            return mapper.Map<PaymentDTO>(data);
        }

        public static List<PaymentDTO> GetPendingPayments()
        {
            var data = DataAccessFactory.PaymentSpecialDataAccess().GetPendingPayments();
            var config = new MapperConfiguration(c => {
                c.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<PaymentDTO>>(data);
        }

        public static bool VerifyPayment(int id)
        {
            return DataAccessFactory.PaymentSpecialDataAccess().Verify(id);
        }

        public static int GetPaidTuition(int id)
        {
            return DataAccessFactory.PaymentSpecialDataAccess().GetTuitionId(id);
        }

    }
}
