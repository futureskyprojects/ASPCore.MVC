﻿using ASPCoreMVC._Commons;
using ASPCoreMVC._Commons.Services;
using ASPCoreMVC.TCUEnglish.ExamSkillCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace ASPCoreMVC.TCUEnglish.SkillCategories
{
    public class SkillCategoryService : WrapperCrudAppService<
        ExamSkillCategory,
        SkillCategoryDTO,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateSkillCategoryDTO>, ISkillCategoryService
    {
        public SkillCategoryService(IRepository<ExamSkillCategory, Guid> repository) : base(repository) { }
        public ResponseWrapper<List<SkillCategoryBaseDTO>> GetBase(Guid exCatId)
        {
            return new ResponseWrapper<List<SkillCategoryBaseDTO>>(
                 ObjectMapper.Map<List<ExamSkillCategory>, List<SkillCategoryBaseDTO>>(
                 Repository.Where(x => x.ExamCategoryId == exCatId)
                 .OrderBy(x => x.Order)
                 .ToList()),
                 "Successful");
        }

        protected override IQueryable<ExamSkillCategory> ApplyDefaultSorting(IQueryable<ExamSkillCategory> query)
        {
            return query.OrderBy(x => x.Order);
        }

        public async Task<ResponseWrapper<CreateUpdateSkillCategoryDTO>> GetDataForUpdate(Guid skillCatId)
        {
            return new ResponseWrapper<CreateUpdateSkillCategoryDTO>(
                ObjectMapper.Map<ExamSkillCategory, CreateUpdateSkillCategoryDTO>(await Repository.GetAsync(skillCatId)),
                "Successful");
        }

        public async Task<ResponseWrapper<bool>> GetHasAsync(Guid skillCatId)
        {
            return new ResponseWrapper<bool>(await Repository.AnyAsync(x => x.Id == skillCatId), "Successful");
        }

        public ResponseWrapper<SkillCategoryBaseDTO> GetSimpify(Guid id)
        {
            return new ResponseWrapper<SkillCategoryBaseDTO>(
                 ObjectMapper.Map<ExamSkillCategory, SkillCategoryBaseDTO>(
                 Repository.Where(x => x.Id == id).FirstOrDefault()),
                 "Successful");
        }

        public async Task PutUpdateOrder(List<Guid> skillCatIds)
        {
            for (int i = 0; i < skillCatIds.Count; i++)
            {
                var record = await Repository.GetAsync(skillCatIds[i]);
                record.Order = i;
                await Repository.UpdateAsync(record);
            }

        }
    }
}
