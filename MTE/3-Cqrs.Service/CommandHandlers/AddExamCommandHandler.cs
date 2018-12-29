﻿using AutoMapper;
using EnsureThat;
using _1_Entity.Model;
using _3_Cqrs.Service.Command;
using _3_Cqrs.Service.CommandContracts;
using _5_Repositories.Contracts;

namespace _3_Cqrs.Service.CommandHandlers
{
    public class AddExamCommandHandler : ICommandHandler<AddExamCommand>
    {
        private readonly IBaseRepository<Exam> examRepository;
        private readonly IMapper mapper;

        public AddExamCommandHandler(IMapper mapper, IBaseRepository<Exam> examRepository)
        {
            this.mapper = mapper;
            this.examRepository = examRepository;
        }

        public void Execute(AddExamCommand command)
        {
            EnsureArg.IsNotNull(command);
            var exam = new Exam();

            mapper.Map(command.Exam, exam);
            examRepository.Add(exam);
            examRepository.Save();
        }
    }
}
