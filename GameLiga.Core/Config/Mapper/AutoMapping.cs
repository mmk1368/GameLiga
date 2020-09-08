using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using GameLiga.Core.DTOModels;
using GameLiga.Infrastructure.Data.Entities;

namespace GameLiga.Core.Config.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateAccountDto, Account>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Email, opt => opt.MapFrom(y => y.Email))
                .ForMember(x => x.FirstName, opt => opt.MapFrom(y => y.FirstName))
                .ForMember(x => x.LastName, opt => opt.MapFrom(y => y.LastName))
                .ForMember(x => x.NickName, opt => opt.MapFrom(y => y.NickName))
                .ForMember(x => x.Password, opt => opt.Ignore())
                .ForMember(x => x.CreateDate, opt => opt.MapFrom(y => DateTime.Now))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(y => y.PhoneNumber))
                .ForMember(x => x.PromotionalCode, opt => opt.MapFrom(y => y.PromotionalCode))
                .ForMember(x => x.Referred, opt => opt.MapFrom(x => x.Referred))
                .ForMember(x => x.Username, opt => opt.MapFrom(y => y.Username));


            CreateMap<News, NewsDTO>()
                .ForMember(x => x.Author, opt => opt.MapFrom(y => y.Author))
                .ForMember(x => x.AuthorId, opt => opt.MapFrom(y => y.AuthorId))
                .ForMember(x => x.CreateDate, opt => opt.MapFrom(y => y.CreateDate))
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.Pic, opt => opt.MapFrom(y => y.Pic))
                .ForMember(x => x.Text, opt => opt.MapFrom(y => y.Text))
                .ForMember(x => x.Title, opt => opt.MapFrom(y => y.Title));

            CreateMap<Account, AccountDTO>()
                .ForMember(x => x.NickName, opt => opt.MapFrom(y => y.NickName));


            CreateMap<NewsDTO, News>()
                .ForMember(x => x.CreateDate, opt => opt.MapFrom(y => y.CreateDate))
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.Pic, opt => opt.MapFrom(y => y.Pic))
                .ForMember(x => x.Text, opt => opt.MapFrom(y => y.Text))
                .ForMember(x => x.Title, opt => opt.MapFrom(y => y.Title));

            CreateMap<File, FileDTO>()
                .ForMember(x => x.FileContent, opt => opt.MapFrom(y => y.FileContent))
                .ForMember(x => x.FileExtention, opt => opt.MapFrom(y => y.FileExtention))
                .ForMember(x => x.FileName, opt => opt.MapFrom(y => y.FileName));

            CreateMap<FileDTO, File>()
                .ForMember(x => x.FileContent, opt => opt.MapFrom(y => y.FileContent))
                .ForMember(x => x.FileExtention, opt => opt.MapFrom(y => y.FileExtention))
                .ForMember(x => x.FileName, opt => opt.MapFrom(y => y.FileName));
        }
    }
}
