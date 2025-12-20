using Application.Dto;
using Application.Dto.AttributeType;
using Application.Dto.Unit;
using Application.Dto.UnitExpense;
using Application.Dto.UnitOwner;
using AutoMapper;
using Domain.Entities;


namespace Application.Profiles
{
    public class MappingMaps:Profile
    {
        public MappingMaps()
        {
            #region Attribute Profiles
            CreateMap<Domain.Entities.Attribute, Dto.Attribute.attributeCreateDto>().ReverseMap();
            CreateMap<Domain.Entities.Attribute, Dto.Attribute.AttributeGetDto>().ReverseMap();
            CreateMap<Domain.Entities.Attribute, Domain.Entities.Attribute>().ForMember(dest => dest.AttributeId, opt => opt.Ignore());
            #endregion

            #region AttribbuteType Profiles
            CreateMap<AttributeType, AttributeTypeGetDto>().ReverseMap();
            CreateMap<AttributeType, AttributeTypeCreateAndUpdateDto>().ReverseMap();
            CreateMap<AttributeType, AttributeType>()
                  .ForMember(dest => dest.AttributeTypeId, opt => opt.Ignore());
            #endregion

            #region Building Profiles
            CreateMap<Building, BuildingCreateDto>().ReverseMap();
            CreateMap<Building, BuildingGetDto>().ReverseMap();
            #endregion 

            #region Compound Profiles
            CreateMap<Domain.Entities.Compounds, Dto.Compound.CompoundCreateDto>().ReverseMap();
            CreateMap<Domain.Entities.Compounds, Dto.Compound.CompoundGetDto>().ReverseMap();
            CreateMap<Domain.Entities.Compounds, Domain.Entities.Compounds>().ForMember(dest => dest.Id, opt => opt.Ignore());
            #endregion

            #region Expense Profiles
            CreateMap<Domain.Entities.Expense, Dto.Expense.ExpenceCreateDto>().ReverseMap();
            CreateMap<Domain.Entities.Expense, Dto.Expense.ExpenseGetDto>().ReverseMap();
            CreateMap<Domain.Entities.Expense, Domain.Entities.Expense>()
              .ForMember(dest => dest.Id, opt => opt.Ignore());
            #endregion

            #region FinancialPeriod Profiles
            CreateMap<Domain.Entities.FinancialPeriod, Dto.FinancialPeriod.FinancialPeriodCreateDto>().ReverseMap();
            CreateMap<Domain.Entities.FinancialPeriod, Dto.FinancialPeriod.FinancialPeriodGetDto>().ReverseMap();
            CreateMap<Domain.Entities.FinancialPeriod, Domain.Entities.FinancialPeriod>().ForMember(dest => dest.Id, opt => opt.Ignore());
            #endregion

            #region Person Profiles
            CreateMap<Persons, PersonDto>().ReverseMap();
            CreateMap<Persons, UserRegisterDto>().ReverseMap();
            #endregion

            #region Resident Profiles
            CreateMap<Dto.Residents.ResidentCreateDto, Domain.Entities.ResidentEntity>().ReverseMap();
            CreateMap<Dto.Residents.ResidentGetDto, Domain.Entities.ResidentEntity>().ReverseMap();
            CreateMap<Domain.Entities.ResidentEntity, Domain.Entities.ResidentEntity>()
              .ForMember(dest => dest.Id, opt => opt.Ignore());
            #endregion

            #region UnitOwner Profiles
            CreateMap<CreateUnitOwnerDto, UnitOwner>().ReverseMap();
            CreateMap<GetUnitOwnerDto, UnitOwner>().ReverseMap();
            #endregion

            #region Unit Profiles
            CreateMap<UnitCreateDto, UnitEntity>().ReverseMap();
            CreateMap<UnitGetDto, UnitEntity>().ReverseMap();
            #endregion
            
            #region UnitExpenses Profiles
            CreateMap<UnitExpense, UnitGetDto>().ReverseMap();
            CreateMap<UnitExpense, UnitExpenseCreateDto>().ReverseMap();
            #endregion
        }
    }
}
