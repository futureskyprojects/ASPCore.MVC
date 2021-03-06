﻿using ASPCoreMVC._Commons;
using ASPCoreMVC._Commons.Services;
using ASPCoreMVC.TCUEnglish.UserExams;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ASPCoreMVC.TCUEnglish.ExamLogs
{
    public interface IExamLogService : IWrapperCrudAppService<ExamLogDTO, Guid, GetExamLogDTO>
    {
        public Task<ResponseWrapper<PagedResultDto<ExamLogBaseDTO>>> GetBaseListAsync(GetExamLogDTO input);
        public Guid? GetLastExamNotFinished();
        public Task ResultProcessing(ExamLogResultDTO examResult);

        public Task UpdateCorrectContentAnswer(Guid examLogId, MicroQuestionDTO inp);
        public Task UpdateInstructorComments(Guid examLogId, string comments);

        public Task<int> GetCompletedTest(Guid examCategoryId);
        public Task<int> GetPassedTest(Guid examCategoryId);
        public Task<int> GetFaildTest(Guid examCategoryId);
        public Task<float> GetGPA(Guid examCategoryId);

        public Task<Guid?> GetCreatorId(Guid examLogId);

        public Task<ExamHistoryStatDTO> GetExamHistoryStats(Guid? destId);
        public Task<PagedResultDto<ExamLogBaseDTO>> GetExamHistories(Guid? destId, PagedAndSortedResultRequestDto input);

        public Task<List<ExamLogStudentDTO>> GetExamLogStudents(Guid examCategoryId);
        public Task<PagedResultDto<ExamLogBaseDTO>> GetStudentExams(Guid? creatorId, PagedAndSortedResultRequestDto input);
    }
}
