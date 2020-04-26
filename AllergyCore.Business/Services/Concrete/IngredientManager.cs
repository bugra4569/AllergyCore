using AllergyCore.Business.Constants;
using AllergyCore.Business.Services.Abstarct;
using AllergyCore.Business.ValidationRules;
using AllergyCore.Core.Aspects.Validation;
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
    public class IngredientManager : IIngredientService
    {
        private IIngredientRepository _ingredientRepository;
        public IngredientManager(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        [ValidationAspect(typeof(IngredientValidator))]
        public IResult Add(Ingredients entity)
        {
            //Aspect yazılmadan önce validationlar bu şekilde yazılır.

            //var validator = new IngredientValidator();
            //var validationResult = validator.Validate(entity);
            //if (!validationResult.IsValid)
            //    return BadRequest(new ErrorResult(Messages.ModelNotValid));
            var checkForAdd = CheckIfSameMaterialAddedSameFood(entity.MaterialId, entity.FoodId);
            if (!checkForAdd.IsSuccess)
                return checkForAdd;
            return new SuccessResult(Messages.IngredientAdded);
        }
        public IDataResult<Ingredients> Get(int id)
        {
            var result = _ingredientRepository.Get(x => x.Id == id);
            if (result == null)
                return new ErrorDataResult<Ingredients>(Messages.IngredientNotFound);
            return new SuccessDataResult<Ingredients>(result);
        }
        public IDataResult<List<Ingredients>> GetAll()
        {
            var result = _ingredientRepository.GetList();
            return new SuccessDataResult<List<Ingredients>>(result.ToList());
        }
        public IResult Remove(int id)
        {
            var checkExist = CheckIfExsist(id);
            if (!checkExist.IsSuccess)
                return checkExist;
            _ingredientRepository.Remove(checkExist.Data);
            return new SuccessResult(Messages.IngredientDeleted);
        }
        public IResult Update(int id, Ingredients entity)
        {
            var checkExist = CheckIfExsist(id);
            if (!checkExist.IsSuccess)
                return checkExist;
            _ingredientRepository.Update(checkExist.Data);
            return new SuccessResult(Messages.IngredientUpdated);

        }
        private IResult CheckIfSameMaterialAddedSameFood(int materialId, int foodId)
        {
            var result = _ingredientRepository.GetList(x => x.FoodId == foodId && x.MaterialId == materialId).Any();
            if (result)
                return new ErrorResult(Messages.MaterialAlreadyExistForSameFood);
            return new SuccessResult();
        }
        private IDataResult<Ingredients> CheckIfExsist(int id)
        {
            var result = _ingredientRepository.Get(x => x.Id == id);
            if (result == null)
                return new ErrorDataResult<Ingredients>(Messages.IngredientNotFound);
            return new SuccessDataResult<Ingredients>(result);
        }
    }
}
