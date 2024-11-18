﻿using TasksApi.Models;

namespace TasksApi.Repository
{
    public interface ITaskRepository
    {
        List<Tasks> GetAllTasks();

        List<TasksWithUsers> GetAllTasksWithUsers();

        bool CreateTask(Tasks task);

        void UpdateTask(Tasks task);

        void DeleteTask(Tasks task);
           
    }
}