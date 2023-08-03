﻿using KTWFeedbackAPI.Interfaces;
using KTWFeedbackAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KTWFeedbackAPI.Services.Commands
{
    public class FeedbackCommandRepo : ICommandRepo<Feedback,string>
    {
        private readonly FeedbackContext _context;
        private readonly ILogger<Feedback> _logger;

        public FeedbackCommandRepo(FeedbackContext context, ILogger<Feedback> logger)
        {
            _context = context;
            _logger = logger;
        }

        //Add Feedback 
        public async Task<Feedback> Add(Feedback item)
        {
            var transaction = _context.Database.BeginTransaction();
            if (item == null)
            {
                _logger.LogError("Empty object being Passed");
                throw new EmptyValueException("Feedback Object is null");
            }
            _logger.LogInformation("Into the Add Method");
            var user = _context.Feedbacks.Add(item);
            if (user == null)
            {
                _logger.LogError("Unable to add object");
                await transaction.RollbackAsync();
                throw new UnableToAddException("Unable To Add Feedback");
            }
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            _logger.LogInformation("Feedback Added Successfully");
            return item;
            throw new UnableToAddException("Unable To Add Feedback");
        }


        //Update Feedback
        public async Task<Feedback> Update(Feedback item)
        {
            var transaction = _context.Database.BeginTransaction();
            if (item == null)
            {
                _logger.LogError("Empty object being Passed");
                await transaction.RollbackAsync();
                throw new EmptyValueException("Feedback Object is null");
            }

            var feedback = await _context.Feedbacks.FirstOrDefaultAsync(x => x.Email == item.Email)
                ?? throw new EmptyValueException("Invalid Object!!! No such feedback Exist!!");

            if (item != null)
            {
                feedback.Review = (item.Review != null && item.Review.Length > 0) ? item.Review : feedback.Review;
                feedback.Rating = item.Rating;
                feedback.ServiceType = (item.ServiceType != null && item.ServiceType.Length > 0) ? item.ServiceType : feedback.ServiceType;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            return feedback;
            throw new UnableToUpdateException("Unable to update the feedback");
        }
    }
}
