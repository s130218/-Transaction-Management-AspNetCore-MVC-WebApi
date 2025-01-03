﻿using System.Text.Json.Serialization;

namespace FinanceService.Services;

public class ServiceResult : IServiceResult
{
    public string MessageType { get; set; }

    public List<string> Message { get; set; }

    public bool Status { get; set; }

    [JsonConstructor]
    public ServiceResult(bool status, List<string> message = null, string messageType = null)
    {
        if (string.IsNullOrEmpty(messageType))
            MessageType = MessageTypeConst.Success;
        else
            MessageType = messageType;
        if (message == null)
            message = new List<string>();
        Message = message;
        Status = status;
    }

    public static ServiceResult Fail(string message)
    {
        return new ServiceResult(false) { Message = new List<string> { message }, MessageType = MessageTypeConst.Warning };
    }

    public static ServiceResult Fail(List<string> messages)
    {
        return new ServiceResult(false) { Message = messages, MessageType = MessageTypeConst.Warning };
    }

    public static ServiceResult Success(string message)
    {
        return new ServiceResult(true) { MessageType = MessageTypeConst.Success, Message = new List<string> { message } };
    }

    public ServiceResult()
    {

    }
}
public static class MessageTypeConst
{
    public static string Success => "Success";
    public static string Danger => "Danger";
    public static string Warning => "Warning";
}

public class ServiceResult<T> : ServiceResult
{

    private T ResposeData { get; set; }
    public T Data
    {
        get => ResposeData;
        set => ResposeData = value;
    }

    public ServiceResult(bool status, List<string> message = null, string messageType = null)
        : base(status, message, messageType)
    {
    }

    public new static ServiceResult<T> Fail(string message)
    {
        return new ServiceResult<T>(false, new List<string> { message }, MessageTypeConst.Warning);
    }

    public new static ServiceResult<T> Success(string message)
    {
        return new ServiceResult<T>(true) { Message = new List<string> { message }, MessageType = MessageTypeConst.Success };
    }

    public static ServiceResult<T> Success(T data)
    {
        return new ServiceResult<T>(true) { Data = data, MessageType = MessageTypeConst.Success };
    }
}