using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autorender.Core;

namespace Autorender.Models.Folders;

[JsonConverter(typeof(JsonModelConverter<Folder, FolderFromRaw>))]
public sealed record class Folder : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    public string? CreatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("created_by");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_by", value);
        }
    }

    public string? FolderNo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("folder_no");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("folder_no", value);
        }
    }

    public bool? IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_active");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_active", value);
        }
    }

    public bool? IsDelete
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_delete");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_delete", value);
        }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public string? ParentFolder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parent_folder");
        }
        init { this._rawData.Set("parent_folder", value); }
    }

    public string? Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("path");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("path", value);
        }
    }

    public string? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    public Workspace? Workspace
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Workspace>("workspace");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workspace", value);
        }
    }

    public string? WorkspaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("workspace_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workspace_id", value);
        }
    }

    public string? WorkspaceNo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("workspace_no");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workspace_no", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.CreatedBy;
        _ = this.FolderNo;
        _ = this.IsActive;
        _ = this.IsDelete;
        _ = this.Name;
        _ = this.ParentFolder;
        _ = this.Path;
        _ = this.Source;
        _ = this.UpdatedAt;
        this.Workspace?.Validate();
        _ = this.WorkspaceID;
        _ = this.WorkspaceNo;
    }

    public Folder() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Folder(Folder folder)
        : base(folder) { }
#pragma warning restore CS8618

    public Folder(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Folder(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderFromRaw.FromRawUnchecked"/>
    public static Folder FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FolderFromRaw : IFromRawJson<Folder>
{
    /// <inheritdoc/>
    public Folder FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Folder.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Workspace, WorkspaceFromRaw>))]
public sealed record class Workspace : JsonModel
{
    public string? WorkspaceNo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("workspace_no");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workspace_no", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.WorkspaceNo;
    }

    public Workspace() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Workspace(Workspace workspace)
        : base(workspace) { }
#pragma warning restore CS8618

    public Workspace(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Workspace(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspaceFromRaw.FromRawUnchecked"/>
    public static Workspace FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkspaceFromRaw : IFromRawJson<Workspace>
{
    /// <inheritdoc/>
    public Workspace FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Workspace.FromRawUnchecked(rawData);
}
