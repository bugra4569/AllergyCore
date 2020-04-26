using AllergyCore.Business.Constants;
using AllergyCore.Business.Services.Abstarct;
using AllergyCore.Core.Dto.Abstract;
using AllergyCore.Core.Dto.Concrete;
using AllergyCore.Entity.EntityFramework.Entities;
using AllergyCore.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllergyCore.Business.Services.Concrete
{
    public class AllergyManager : IAllergyService
    {
        private IAllergyRepository _allergyRepository;
        public AllergyManager(IAllergyRepository allergyRepository)
        {
            _allergyRepository = allergyRepository;
        }
        public IResult Add(Allergies entity)
        {
            var result = CheckAllergyName(entity.Name);
            if (!result.IsSuccess) return result;
            _allergyRepository.Add(entity);
            return new SuccessResult(Messages.AllergyAdded);
        }

        public IDataResult<Allergies> Get(int id)
        {
            var result = _allergyRepository.Get(x => x.Id == id);
            if (result == null)
                return new ErrorDataResult<Allergies>(Messages.AllergyNotFound);
            return new SuccessDataResult<Allergies>(result);
        }

        public IDataResult<List<Allergies>> GetAll()
        {
            var result = _allergyRepository.GetList().ToList();
            return new SuccessDataResult<List<Allergies>>(result);
        }

        public IResult Remove(int id)
        {
            var allergyCheck = CheckAllergyExist(id);
            if (!allergyCheck.IsSuccess)
                return new ErrorResult(allergyCheck.Message);
            _allergyRepository.Remove(allergyCheck.Data);
            return new SuccessResult(Messages.AllergyDeleted);

        }

        public IResult Update(int id, Allergies entity)
        {
            var allergyCheck = CheckAllergyExist(id);
            if (!allergyCheck.IsSuccess)
                return new ErrorResult(allergyCheck.Message);
            _allergyRepository.Update(entity);
            return new SuccessResult(Messages.AllergyUpdated);
        }
        private IResult CheckAllergyName(string allergyName)
        {
            var result = _allergyRepository.GetList(x => x.Name == allergyName && x.RowStatus == 0).Any();
            if (result)
                return new ErrorResult(Messages.AllergyNameAlreadyExist);
            return new SuccessResult();
        }
        private IDataResult<Allergies> CheckAllergyExist(int id)
        {
            var result = _allergyRepository.Get(x => x.Id == id);
            if (result == null)
                return new ErrorDataResult<Allergies>(Messages.AllergyNotFound);
            return new SuccessDataResult<Allergies>(result);
        }
    }
}
