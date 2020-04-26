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
    public class MaterialManager : IMaterialService
    {
        private IMaterialRepository _materialRepository;
        public MaterialManager(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }
        public IResult Add(Materials entity)
        {
            var checkResult = CheckIfNameUsed(entity.Name);
            if (!checkResult.IsSuccess)
                return checkResult;
            return new SuccessResult(Messages.MaterialAdded);



        }

        public IDataResult<Materials> Get(int id)
        {
            var checkResult = CheckIfExsist(id);
            if (!checkResult.IsSuccess)
                return new ErrorDataResult<Materials>(checkResult.Message);
            return new SuccessDataResult<Materials>(checkResult.Data);

        }

        public IDataResult<List<Materials>> GetAll()
        {
            return new SuccessDataResult<List<Materials>>(_materialRepository.GetList().ToList());
        }

        public IResult Remove(int id)
        {
            var checkResult = CheckIfExsist(id);
            if (!checkResult.IsSuccess)
                return checkResult;
            _materialRepository.Remove(checkResult.Data);
            return new SuccessResult(Messages.MaterialDeleted);
        }

        public IResult Update(int id, Materials entity)
        {
            var checkResult = CheckIfExsist(id);
            if (!checkResult.IsSuccess)
                return checkResult;
            _materialRepository.Update(entity);
            return new SuccessResult(Messages.MaterialDeleted);
        }
        private IResult CheckIfNameUsed(string name)
        {
            var isExist = _materialRepository.GetList(x => x.Name == name).Any();
            if (isExist)
                return new ErrorResult(Messages.MaterialNameAlreadyExist);
            return new SuccessResult();
        }
        private IDataResult<Materials> CheckIfExsist(int id)
        {
            var result = _materialRepository.Get(x => x.Id == id);
            if (result == null)
                return new ErrorDataResult<Materials>(Messages.MaterialNotFound);
            return new SuccessDataResult<Materials>(result);
        }
    }
}
