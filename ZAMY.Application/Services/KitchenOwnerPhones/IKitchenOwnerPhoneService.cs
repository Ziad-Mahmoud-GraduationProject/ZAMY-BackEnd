using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Application.Services.KitchenOwnerPhones
{
    public interface IKitchenOwnerPhoneService
    {
        void Add(KitchenOwnerPhone kitchenownerphone);
        bool IsMatching(string phone);
    }
}
