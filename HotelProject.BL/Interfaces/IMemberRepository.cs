using HotelProject.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BL.Interfaces
{
    public interface IMemberRepository
    {
        void AddMember(Member member, int customerid);
        void UpdateMember(Member member, int customerid,string name);
        void DeleteMember(Member member,int customerid);
    }
}
