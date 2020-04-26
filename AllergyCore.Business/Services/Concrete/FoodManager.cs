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
    public class FoodManager : IFoodService
    {
        private IFoodRepository _foodRepository;
        public FoodManager(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }
        public IResult Add(Foods food)
        {
            var result = CheckFoodNameExists(food.Name);
            if (!result.IsSuccess)
                return result;
            _foodRepository.Add(food);
            return new SuccessResult(Messages.FoodAdded);
        }

        public IDataResult<Foods> Get(int id)
        {
            var checkExisting = CheckIfExist(id);
            if (!checkExisting.IsSuccess)
                return new ErrorDataResult<Foods>(checkExisting.Message);
            return new SuccessDataResult<Foods>(checkExisting.Data);
        }
        public IDataResult<List<Foods>> GetAll()
        {
            return new SuccessDataResult<List<Foods>>(_foodRepository.GetList().ToList());
        }
        public IDataResult<List<Foods>> GetListByAllergyId(int allergyId)
        {
            return new SuccessDataResult<List<Foods>>(_foodRepository.GetList(x => x.Ingredients.Where(a => a.Material.Allergies.Where(b => b.Id == allergyId).Any()).Any()).ToList());

        }
        public IDataResult<List<Foods>> GetListByMaterialId(int materialId)
        {
            return new SuccessDataResult<List<Foods>>(_foodRepository.GetList(x => x.Ingredients.Where(i => i.Material.Id == materialId).Any()).ToList());

        }
        public IResult Remove(int id)
        {
            var check = CheckIfExist(id);
            if (!check.IsSuccess)
                return check;
            _foodRepository.Remove(check.Data);
            return new SuccessDataResult<Foods>(Messages.FoodDeleted);
        }
        public IResult Update(int id, Foods food)
        {
            throw new NotImplementedException();
        }
        private IResult CheckFoodNameExists(string foodName)
        {
            var result = _foodRepository.GetList(x => x.Name == foodName && x.RowStatus == 0).Any();
            if (result)
                return new ErrorResult(Messages.FoodNameAlredyExist);
            return new SuccessResult();
        }
        private IDataResult<Foods> CheckIfExist(int id)
        {
            var result = _foodRepository.Get(x => x.Id == id);
            if (result == null)
                return new ErrorDataResult<Foods>(Messages.FoodNotFound);
            return new SuccessDataResult<Foods>(result);
        }
    }
}
