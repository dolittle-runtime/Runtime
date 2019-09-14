// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: dolittle/application/client/connection_status.proto
// </auto-generated>
// Original file comments:
// ---------------------------------------------------------------------------------------------
//  Copyright (c) Dolittle. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// --------------------------------------------------------------------------------------------
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Dolittle.Runtime.Application.Grpc.Client {
  /// <summary>
  /// Represents the Client Status service
  /// </summary>
  public static partial class ConnectionStatus
  {
    static readonly string __ServiceName = "dolittle.runtime.application.ConnectionStatus";

    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Empty.Parser.ParseFrom);

    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::Google.Protobuf.WellKnownTypes.Empty> __Method_Connect = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "Connect",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_google_protobuf_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Dolittle.Runtime.Application.Grpc.Client.ConnectionStatusReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ConnectionStatus</summary>
    [grpc::BindServiceMethod(typeof(ConnectionStatus), "BindService")]
    public abstract partial class ConnectionStatusBase
    {
      public virtual global::System.Threading.Tasks.Task Connect(grpc::IAsyncStreamReader<global::Google.Protobuf.WellKnownTypes.Empty> requestStream, grpc::IServerStreamWriter<global::Google.Protobuf.WellKnownTypes.Empty> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for ConnectionStatus</summary>
    public partial class ConnectionStatusClient : grpc::ClientBase<ConnectionStatusClient>
    {
      /// <summary>Creates a new client for ConnectionStatus</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public ConnectionStatusClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ConnectionStatus that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public ConnectionStatusClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected ConnectionStatusClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected ConnectionStatusClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual grpc::AsyncDuplexStreamingCall<global::Google.Protobuf.WellKnownTypes.Empty, global::Google.Protobuf.WellKnownTypes.Empty> Connect(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Connect(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncDuplexStreamingCall<global::Google.Protobuf.WellKnownTypes.Empty, global::Google.Protobuf.WellKnownTypes.Empty> Connect(grpc::CallOptions options)
      {
        return CallInvoker.AsyncDuplexStreamingCall(__Method_Connect, null, options);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override ConnectionStatusClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ConnectionStatusClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(ConnectionStatusBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Connect, serviceImpl.Connect).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ConnectionStatusBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Connect, serviceImpl == null ? null : new grpc::DuplexStreamingServerMethod<global::Google.Protobuf.WellKnownTypes.Empty, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.Connect));
    }

  }
}
#endregion
