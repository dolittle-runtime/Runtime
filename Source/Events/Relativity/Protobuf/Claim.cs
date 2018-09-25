// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: dolittle/interaction/events.relativity/claim.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Dolittle.Runtime.Events.Relativity.Protobuf {

  /// <summary>Holder for reflection information generated from dolittle/interaction/events.relativity/claim.proto</summary>
  public static partial class ClaimReflection {

    #region Descriptor
    /// <summary>File descriptor for dolittle/interaction/events.relativity/claim.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ClaimReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CjJkb2xpdHRsZS9pbnRlcmFjdGlvbi9ldmVudHMucmVsYXRpdml0eS9jbGFp",
            "bS5wcm90bxIaZG9saXR0bGUuZXZlbnRzLnJlbGF0aXZpdHkiNwoFQ2xhaW0S",
            "DAoEbmFtZRgBIAEoCRINCgV2YWx1ZRgCIAEoCRIRCgl2YWx1ZVR5cGUYAyAB",
            "KAlCLqoCK0RvbGl0dGxlLlJ1bnRpbWUuRXZlbnRzLlJlbGF0aXZpdHkuUHJv",
            "dG9idWZiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Dolittle.Runtime.Events.Relativity.Protobuf.Claim), global::Dolittle.Runtime.Events.Relativity.Protobuf.Claim.Parser, new[]{ "Name", "Value", "ValueType" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// Represents the Claim
  /// </summary>
  public sealed partial class Claim : pb::IMessage<Claim> {
    private static readonly pb::MessageParser<Claim> _parser = new pb::MessageParser<Claim>(() => new Claim());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Claim> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Dolittle.Runtime.Events.Relativity.Protobuf.ClaimReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Claim() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Claim(Claim other) : this() {
      name_ = other.name_;
      value_ = other.value_;
      valueType_ = other.valueType_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Claim Clone() {
      return new Claim(this);
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 1;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "value" field.</summary>
    public const int ValueFieldNumber = 2;
    private string value_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Value {
      get { return value_; }
      set {
        value_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "valueType" field.</summary>
    public const int ValueTypeFieldNumber = 3;
    private string valueType_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ValueType {
      get { return valueType_; }
      set {
        valueType_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Claim);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Claim other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      if (Value != other.Value) return false;
      if (ValueType != other.ValueType) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Value.Length != 0) hash ^= Value.GetHashCode();
      if (ValueType.Length != 0) hash ^= ValueType.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Name.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Name);
      }
      if (Value.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Value);
      }
      if (ValueType.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(ValueType);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Value.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Value);
      }
      if (ValueType.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ValueType);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Claim other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Value.Length != 0) {
        Value = other.Value;
      }
      if (other.ValueType.Length != 0) {
        ValueType = other.ValueType;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Name = input.ReadString();
            break;
          }
          case 18: {
            Value = input.ReadString();
            break;
          }
          case 26: {
            ValueType = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
