﻿namespace RhythmicGymnasticsPortal.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using Models;
    using RhythmicGymnasticsPortal.Data.Repositories;

    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> comments;

        public CommentsService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public Comment AddComment(Comment toAdd)
        {
            toAdd.DateCreated = DateTime.UtcNow;
            this.comments.Add(toAdd);
            this.comments.SaveChanges();

            return toAdd;
        }

        public IQueryable<Comment> AllComments()
        {
            return this.comments.All();
        }

        public IQueryable<Comment> CommentsByNews(int id)
        {
            return this.comments.All()
                .Where(x => x.NewsId == id);
        }

        public void Delete(Comment toDelete)
        {
            this.comments.Delete(toDelete);
            this.comments.SaveChanges();
        }
    }
}
