﻿using System.Net;

namespace EnterComputers.Domain.Exceptions;

public class AlreadyExixtsExcaption : Exception 
{
    public HttpStatusCode StatusCode { get;  } = HttpStatusCode.NotFound;

    public string TitleMessage { get; protected set; } = string.Empty;
}
