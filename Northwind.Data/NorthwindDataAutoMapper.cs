using AutoMapper;
using EasyLOB.Data;
using System;
using System.Reflection;

namespace Northwind.Data
{
    public class NorthwindDataAutoMapper : Profile
    {
        public NorthwindDataAutoMapper()
        {
            Assembly dataAssembly = Assembly.GetExecutingAssembly();

            Type baseType = typeof(ZDataBase);
            Type[] types = dataAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.IsSubclassOf(baseType))
                {
                    string dto = type.FullName + "DTO";
                    Type typeDTO = dataAssembly.GetType(dto);

                    CreateMap(type, typeDTO);
                    CreateMap(typeDTO, type);
                }
            }
        }
    }
}
