﻿namespace Example.Application.Dtos
{
    public class GetResult<T> : OutputBase
    {
        public T Data { get; set; }
    }
}