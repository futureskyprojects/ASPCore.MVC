﻿using ASPCoreMVC._Commons;
using ASPCoreMVC._Commons.Services;
using ASPCoreMVC.TCUEnglish.ExamSkillParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace ASPCoreMVC.TCUEnglish.SkillParts
{
    public class SkillPartService : WrapperCrudAppService<
        ExamSkillPart,
        SkillPartDTO,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateSkillPartDTO>, ISkillPartService
    {
        public SkillPartService(IRepository<ExamSkillPart, Guid> repository) : base(repository) { }

        public ResponseWrapper<List<SkillPartBaseDTO>> GetBase(Guid skillCatId)
        {
            return new ResponseWrapper<List<SkillPartBaseDTO>>(
                            ObjectMapper.Map<List<ExamSkillPart>, List<SkillPartBaseDTO>>(
                            Repository.Where(x => x.ExamSkillCategoryId == skillCatId)
                            .OrderBy(x => x.Order).ToList()),
                            "Successful");
        }

        protected override IQueryable<ExamSkillPart> ApplyDefaultSorting(IQueryable<ExamSkillPart> query)
        {
            return query.OrderBy(x => x.Order);
        }

        public async Task<ResponseWrapper<CreateUpdateSkillPartDTO>> GetDataForUpdate(Guid skillPartId)
        {
            return new ResponseWrapper<CreateUpdateSkillPartDTO>(
                ObjectMapper.Map<ExamSkillPart, CreateUpdateSkillPartDTO>(await Repository.GetAsync(skillPartId)),
                "Successful");
        }

        public async Task<ResponseWrapper<bool>> GetHasAsync(Guid skillPartId)
        {
            return new ResponseWrapper<bool>(await Repository.AnyAsync(x => x.Id == skillPartId), "Successful");
        }

        public ResponseWrapper<SkillPartBaseDTO> GetSimpify(Guid id)
        {
            return new ResponseWrapper<SkillPartBaseDTO>(
                           ObjectMapper.Map<ExamSkillPart, SkillPartBaseDTO>(
                           Repository.Where(x => x.Id == id).FirstOrDefault()),
                           "Successful");
        }

        public async Task PutUpdateOrder(List<Guid> skillPartIds)
        {
            for (int i = 0; i < skillPartIds.Count; i++)
            {
                var record = await Repository.GetAsync(skillPartIds[i]);
                record.Order = i;
                await Repository.UpdateAsync(record);
            }

        }
    }
}
