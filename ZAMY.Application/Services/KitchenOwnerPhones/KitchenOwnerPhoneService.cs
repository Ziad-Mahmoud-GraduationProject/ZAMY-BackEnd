using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZAMY.Application.Services.KitchenOwnerPhones
{
    internal class KitchenOwnerPhoneService(IUnitOfWork _unitOfWork) : IKitchenOwnerPhoneService
    {
        public void Add(KitchenOwnerPhone kitchenownerphone)
        {
           _unitOfWork.KitchenOwnerPhones.Add(kitchenownerphone);
            _unitOfWork.Complete();
        }

        public bool IsMatching(string phone)
        {
            const string pattern = @"^\(?\d{3}\)?[-.\s]\d{3}[-.\s]\d{4}$|^\d{11}$|^\d{3} \d{7}$";
            var match= Regex.Match(phone, pattern);
            return match.Success;
        }
    }
}
