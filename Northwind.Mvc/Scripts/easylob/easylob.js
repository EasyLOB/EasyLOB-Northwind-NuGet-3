/*

JavaScript
    function zAlert(message, modal = true)
    function zConfirm(message)
    function zCompareValues(key, order = "asc")
    function zConsole(message)
    function zContains(array, value)
    function zDateAddDay(date, n)
    function zDateAddMonth(date, n)
    function zDateAddYear(date, n)
    function zEnter2Tab()
    function zFormat(string, args)
    function zGUID()
    function zISODate(value)
    function zIsValue(value)
    function zOne(value)
    function zParseFloat(value)
    function zParseInt(value)
    function zParseJSON(json)
    function zReadOnly(parentId, readOnly = true)
    function zReplaceAll(string, find, replace)
    function zRound(value, exp)
    function zSleepMS(milliseconds)
    function zSleepS(seconds)
    function zZero(value)
AJAX
    function zAjaxError(jqXHR)
    function zAjaxFailure(jqXHR, textStatus, errorThrown)
    function zAjaxLoadAsync(id, ajaxUrl)
    function zAjaxLoadSync(id, ajaxUrl)
    function zAjaxLoadComplete(responseText, textStatus, jqXHR, id)
    function zAjaxSuccess(data, textStatus, jqXHR)
EDM
    function zEDMCssClass(fileAcronym)
Errors & Exceptions
    function zExceptionMessage(fileName, functionName, exception)
    function zShowOperationResult(operationResult)
Local Storage
    function zLocalStorageClear()
    function zLocalStorageGet(item)
    function zLocalStorageRemove(item)
    function zLocalStorageSet(item, data)
On*View
    Collection
        function zOnCollectionView(model, profile, dataSourceUrl)
        function zOnCollectionViewActionBegin(model, args)
        function zOnCollectionViewActionBeginSCRUD(model)
        function zOnCollectionViewRead(model, profile)
        function zOnCollectionViewWrite(model, profile, args)
    CRUD
        function zOnCRUDView(model)
    Item
        function zOnItemView(model, profile)
    Lookup
        function zOnLookupView(model, profile, gridId)
        function zOnLookupViewActionBegin(model, args)
        function zOnLookupViewRead(model, profile)
        function zOnLookupViewWrite(model, profile, args)
Session Storage
    function zSessionStorageClear()
    function zSessionStorageGet(item)
    function zSessionStorageRemove(item)
    function zSessionStorageSet(item, data)
Syncfusion
    function zGrid(gridId)
    function zGridDataManager(gridId, dataSourceUrl, functionBeforeSend, isRefresh)
    function zGridDataSource(gridId, dataSourceUrl, isRefresh)
    function zLookupElements(data, elements, culture)
    function zSyncfusionCollection(id)
    function zSyncfusionCollectionReady(id)
    function zSyncfusionItem(id)
    function zSyncfusionItemReady(id)
    function zSyncfusionLookup(id)
    function zSyncfusionLookupReady(id)
    function zTab(tabId)

*/

//// JavaScript

/*
if (!value)
    null
    undefined
    NaN
    ""
    0
    false
*/

function zAlert(message, modal = true) {
    if (message) {
        message = "<h4>" + message + "</h4>";
    }

    $("#ZAlert").html(message);
    if (message) {
        $("#ZAlert").ejDialog({
            height: 270,
            maxHeight: 540,
            minHeight: 270,
            width: 960,
            maxWidth: 1140,
            minWidth: 540
        });
        $("#ZAlert").ejDialog("open");
        $("#ZAlert").ejDialog({ enableModal: modal })
    }
}

function zConfirm(message) {
    return confirm(message);
}

// items.sort(compareValues("property"));
// items.sort(compareValues("property", "desc"));
function zCompareValues(key, order = "asc") {
    return function (a, b) {
        if (!a.hasOwnProperty(key) || !b.hasOwnProperty(key)) {
            return 0;
        }

        const varA = (typeof a[key] === "string") ? a[key].toUpperCase() : a[key];
        const varB = (typeof b[key] === "string") ? b[key].toUpperCase() : b[key];

        let comparison = 0;
        if (varA > varB) {
            comparison = 1;
        } else if (varA < varB) {
            comparison = -1;
        }

        return ((order == "desc") ? (comparison * -1) : comparison);
    };
}

function zConsole(message) {
    //console.error(message);
    console.info(message);
    //console.log(message);
    //console.warn(message);
}

function zContains(array, value) {
    return array.indexOf(value) >= 0;
}

function zDateAddDay(date, n) {
    return new Date(date.setDay(date.getMonth() + n));
}

function zDateAddMonth(date, n) {
    return new Date(date.setMonth(date.getMonth() + n));
}

function zDateAddYear(date, n) {
    return new Date(date.setYear(date.getMonth() + n));
}

function zEnter2Tab() {
    $("input").keydown(function (e) {
        var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
        if (key === 13) {
            e.preventDefault();
            var inputs = $(this).closest("form").find(":input:visible");
            inputs.eq(inputs.index(this) + 1).focus();
        }
    });
}

function zFormat(string, args) {
    // format("{0} or {1}", ["Black", "White"])); 
    $.each(args, function (i, n) {
        string = string.replace(new RegExp("\\{" + i + "\\}", "g"), n);
    });

    return string;
}

function zGUID() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

function zISODate(value) {
    return value ? new Date(value) : value;
}

function zIsValue(value) {
    /*
        null
        undefined
        NaN
        ""
        0
        false
    */
    var result = false;

    if (value) {
        result = true;
    }

    return result;
}

function zOne(value) {
    return !value || value < 1 ? 1 : value;
}

function zParseFloat(value) {
    var result;

    try {
        var result = parseFloat(value);
        if (result != 0) {
            if (!result || !(typeof result === "number")) {
                result = null;
            }
        }
    }
    catch (exception) {
        result = null;
    }

    return result;
}

function zParseInt(value) {
    var result;

    try {
        var result = parseInt(value);
        if (result != 0) {
            if (!result || !(typeof result === "number")) {
                result = null;
            }
        }
    }
    catch (exception) {
        result = null;
    }

    return result;
}

function zParseJSON(json) {
    var result;

    try {
        var result = JSON.parse(json);
        if (!result || !(typeof result === "object")) {
            result = null;
        }
    }
    catch (exception) {
        result = null;
    }

    return result;
}

function zReadOnly(parentId, readOnly = true) {
    var parentId = "#" + parentId;
    $(parentId + " input.form-control").not(":input[type=button], :input[type=image], :input[type=reset], :input[type=submit]").prop("readonly", readOnly);
    // ReadOnly.js
    // https://github.com/haggen/readonly
    $(parentId + " select").readonly(readOnly);
    //readonly(parentId + " select", readOnly);
    $(parentId + " textarea").prop("readonly", readOnly);
    $(parentId + " input[name*='_Lookup'][type!='checkbox']").prop("readonly", true);
    if (readOnly) {
        $(parentId + " input[type='checkbox']").prop("disabled", true);

        $(parentId + " input[data-role='ejdatepicker']").each(function () {
            $(this).data("ejDatePicker").option("readOnly", true);
        });
        $(parentId + " input[data-role='ejdatetimepicker']").each(function () {
            $(this).data("ejDateTimePicker").option("readOnly", true);
        });

        $(parentId + " img.z-buttonLookup").hide();
    }
    else {
        $(parentId + " img.z-buttonLookup").show();
    }
}

function zReplaceAll(string, find, replace) {
    return string.replace(new RegExp(find, 'g'), replace);
}

function zRound(value, exp) {

    // Formatting a number with exactly two decimals in JavaScript
    // https://stackoverflow.com/questions/1726630/formatting-a-number-with-exactly-two-decimals-in-javascript
    // round(1.275, 2); // 1.28
    // round(1.27499, 2); // 1.27
    // round(1234.5678, -2); // 1200
    // round(1.2345678e+2, 2); // 123.46
    // round("123.45"); // 123

    if (typeof exp === 'undefined' || +exp === 0) {
        return Math.round(value);
    }

    value = +value;
    exp = +exp;

    if (isNaN(value) || !(typeof exp === 'number' && exp % 1 === 0)) {
        return NaN;
    }

    // Shift
    value = value.toString().split('e');
    value = Math.round(+(value[0] + 'e' + (value[1] ? (+value[1] + exp) : exp)));

    // Shift Back
    value = value.toString().split('e');
    return +(value[0] + 'e' + (value[1] ? (+value[1] - exp) : -exp));
}

function zSleepMS(milliseconds) {
    var dateTime = new Date().getTime();
    while ((new Date().getTime() - dateTime) < milliseconds);
}

function zSleepS(seconds) {
    seconds = (+new Date) + seconds * 1000;
    while ((+new Date) < seconds);
}

function zZero(value) {
    return !value ? 0 : value;
}

//// AJAX

// jqXHR = jQuery XMLHttpRequest

/*
done data
{
    "Response":
    {
        "Preco":0
    }
}

done jqXHR
{
    "readyState":4,
    "responseText":
    {
        "Response":
        {
            "Preco":0
        }
    },
    "responseJSON":
    {
        "Response":
        {
            "Preco":0
        }
    },
    "status":200,
    "statusText":"OK"
}

fail jqXHR
{
    "readyState":4,
    "responseText":
    {
        "OperationResult":
        {
            "Data":null,"ErrorCode":"","ErrorMessage":"","Html":"\\u003clabel class=\\"label label-danger\\"\\u003eErro: ERRO\\u003c/label\\u003e\\u003cbr /\\u003e","Ok":false,"StatusCode":"","StatusMessage":"","OperationErrors":[{"ErrorCode":"","ErrorMessage":"Siegmar I. J. Gieseler","ErrorMembers":[]}],"Text":"Erro: Siegmar I. J. Gieseler\\n"}}","responseJSON":{"OperationResult":{"Data":null,"ErrorCode":"","ErrorMessage":"","Html":"Erro: Siegmar I. J. Gieseler","Ok":false,"StatusCode":"","StatusMessage":"","OperationErrors":[{"ErrorCode":"","ErrorMessage":"ERRO","ErrorMembers":[]}],"Text":"Erro: ERRO\n"
        }
    },
    "status":400,
    "statusText":"Bad Request"
}
*/

function zAjaxError(jqXHR) {
    var error = "";

    if (jqXHR) {
        if (jqXHR.responseJSON) {
            if (jqXHR.responseJSON.OperationResult) {
                error = jqXHR.responseJSON.OperationResult.Html;
            } else {
                error = jqXHR.responseJSON;
            }
        } else if (jqXHR.responseText) {
            var response = zParseJSON(jqXHR.responseText);
            if (response && response.OperationResult) {
                error = response.OperationResult.Html;
            } else {
                error = jqXHR.responseText;
            }
        } else {
            error = JSON.stringify(jqXHR);
        }
    }

    return error;
}

function zAjaxFailure(jqXHR, textStatus, errorThrown) {
    try {
        if (jqXHR && jqXHR.responseJSON && jqXHR.responseJSON.Url) {
            window.location.replace(jqXHR.responseJSON.Url);
        }

        zAlert(zAjaxError(jqXHR));
    } catch (exception) {
        zExceptionMessage("", "zAjaxFailure", exception.message);
    }
}

function zAjaxLoadAsync(id, ajaxUrl) {
    $("#" + id).load(ajaxUrl, function (responseText, textStatus, jqXHR) {
        zAjaxLoadComplete(responseText, textStatus, jqXHR, id);
    });
    //$("#" + id).load(ajaxUrl);
}

function zAjaxLoadSync(id, ajaxUrl) {
    try {
        jQuery.ajaxSetup({ async: false });
        $("#" + id).load(ajaxUrl, function (responseText, textStatus, jqXHR) {
            zAjaxLoadComplete(responseText, textStatus, jqXHR, id);
        });
        //$("#" + id).load(ajaxUrl);
    } finally {
        jQuery.ajaxSetup({ async: true });
    }
}

function zAjaxLoadComplete(responseText, textStatus, jqXHR, id) {
    try {
        if (jqXHR) { // @aJAX.ZImageLink
            var response = zParseJSON(jqXHR.responseText);
            if (response && response.Url) {
                window.location.replace(response.Url);
            }
        }

        if (textStatus === "error") {
            zAlert(zAjaxError(jqXHR));
        } else {
            if (!id) {
                id = "ZAjax";
            }
            ej.widget.init($("#" + id));
        }
    } catch (exception) {
        zExceptionMessage("", "zAjaxLoadComplete", exception.message);
    }
}

function zAjaxSuccess(data, textStatus, jqXHR) {
    try {
        if (data) {
            if (data.OperationResult) {
                zShowOperationResult(data.OperationResult);
            }

            var url = data.Url;
            if (!url) {
                var controller = data.Controller;
                if (controller) {
                    url = zUrlDictionaryRead(controller);
                }
            }
            if (url) {
                $("#ZAjax").load(url, function (responseText, textStatus, jqXHR) {
                    zAjaxLoadComplete(responseText, textStatus, jqXHR);
                });
            }
        }
    } catch (exception) {
        zExceptionMessage("", "zAjaxSuccess", exception.message);
    }
}

//// EDM

function zEDMCssClass(fileAcronym) {
    var cssClass = "";

    switch (fileAcronym) {
        case "mp3":
            cssClass = "z-fileAudio";
            break;
        case "xls":
        case "xlsx":
            cssClass = "z-fileExcel";
            break;
        case "jpg":
        case "png":
            cssClass = "z-fileImage";
            break;
        case "pdf":
            cssClass = "z-filePDF";
            break;
        case "avi":
        case "mov":
        case "mp4":
        case "mpeg":
        case "wmv":
            cssClass = "z-fileVideo";
            break;
        case "doc":
        case "docx":
            cssClass = "z-fileWord";
            break;
        default:
            cssClass = "z-fileUnknown";
            break;
    }

    return cssClass;
}

//// Errors & Exceptions

function zExceptionMessage(fileName, functionName, exception) {
    fileName = fileName ? fileName : "";
    functionName = functionName ? functionName : "";
    var message = exception && exception.message ? exception.message : "";
    var stack = exception && exception.stack ? exception.stack : "";

    return "<b>File:</b> " + fileName +
        "<br/><b>Function:</b> " + functionName+
        "<br/><b>Exception:</b> " + message +
        "<br/><button data-toggle='collapse' data-target='#zStack'>...</button>" +
        "<div id='zStack' class='collapse'>" + zReplaceAll(stack, "  at ", "<br/>at ") + "</div>";
}

function zShowOperationResult(operationResult) {
    if (operationResult.Html) {
        zAlert(operationResult.Html);
    }
}

//// Local Storage - Persistent

function zLocalStorageClear() {
    window.localStorage.clear();
}

function zLocalStorageGet(item) {
    return window.localStorage.getItem(item);
}

function zLocalStorageRemove(item) {
    return window.localStorage.removeItem(item);
}

function zLocalStorageSet(item, data) {
    window.localStorage.setItem(item, data);
}

//// On*View

function zOnCollectionView(model, profile, dataSourceUrl) {
    var ejGrid = zGrid("Grid_" + profile.Name);

    // Master-Detail Filtering & Search
    if (model.IsMasterDetail) {
        // Filtering
        if (ejGrid.model.filterSettings.filteredColumns.length > 0) {
            ejGrid.clearFiltering();
        }
        // Search
        if (ejGrid.model.searchSettings.key) {
            ejGrid.clearSearching();
        }
        // Current Page
        if (ejGrid.model.pageSettings.currentPage !== 1) {
            ejGrid.model.pageSettings.currentPage = 1;
        }
    }
    else {
        var search = zSearchDictionaryRead(profile.Name);
        if (search) {
            ejGrid.model.searchSettings.key = search;
            $("#Grid_" + profile.Name + "_searchbar").val(search);
        }    
    }

    ejGrid.model.searchSettings.fields = profile.GridSearchProperties;

    //if (!model.IsMasterDetail) {
    //    ejGrid.setModel({
    //        allowGrouping: true,
    //        toolbarSettings: {
    //            toolbarItems: [
    //                ej.Grid.ToolBarItems.Search,
    //                ej.Grid.ToolBarItems.Add,
    //                ej.Grid.ToolBarItems.Edit,
    //                ej.Grid.ToolBarItems.Delete
    //                //ej.Grid.ToolBarItems.ExcelExport,
    //                //ej.Grid.ToolBarItems.PdfExport,
    //                //ej.Grid.ToolBarItems.WordExport
    //            ]
    //        }
    //    });
    //} else {
    //    ejGrid.setModel({
    //        allowGrouping: false,
    //        toolbarSettings: {
    //            toolbarItems: [
    //                ej.Grid.ToolBarItems.Search,
    //                ej.Grid.ToolBarItems.Add,
    //                ej.Grid.ToolBarItems.Edit,
    //                ej.Grid.ToolBarItems.Delete
    //            ]
    //        }
    //    });
    //}

    // Tooltip
    $("#Grid_" + profile.Name + "_Grid_" + profile.Name + "_Toolbar").removeAttr("data-content");

    // DataSource
    if (dataSourceUrl) {
        if (!model.IsMasterDetail) {
            zGridDataSource("Grid_" + profile.Name, dataSourceUrl);
        }
    }

    // <div></div>
    // Search.cshtml                <div style = "display: none
    // _EntityCollection.cshtml         <div id="Collection_Entity">
    $("#Collection_" + profile.Name).parent().show();

    // Activity
    //if (model.ActivityOperations.IsSearch) {
    //    $("#Collection_" + profile.Name).css("display", "block");
    //}
    //else {
    //    $("#Collection_" + profile.Name).css("display", "none");
    //}

    zShowOperationResult(model.OperationResult);
}

function zOnCollectionViewActionBegin(model, args) {
    if (args.requestType == "add" || args.requestType == "beginedit" || args.requestType == "delete") {
        args.cancel = true;
    } else if (args.requestType == "filtering") {
        if (args.currentFilterObject && args.currentFilterObject.length > 0 && args.currentFilterObject[0].operator == "startswith") {
            args.currentFilterObject[0].operator = "contains";
        }
    }
}

function zOnCollectionViewActionBeginSCRUD(model) {
    var scrud = { isSearch: false, isCreate: false, isRead: false, isUpdate: false, isDelete: false };

    scrud.isSearch = !model.IsMasterDetail;

    scrud.isCreate = true;
    scrud.isRead = true;
    scrud.isUpdate = true;
    scrud.isDelete = true;

    //var masterControllerAction = model.MasterControllerAction == null ? "" : model.MasterControllerAction.toLowerCase();
    //scrud.isCreate = masterControllerAction == "" || masterControllerAction == "update";
    //scrud.isRead = masterControllerAction == "" || masterControllerAction == "read" || masterControllerAction == "update" || masterControllerAction == "delete";
    //scrud.isUpdate = masterControllerAction == "" || masterControllerAction == "update";
    //scrud.isDelete = masterControllerAction == "" || masterControllerAction == "update" || masterControllerAction == "delete";

    return scrud;
}

function zOnCollectionViewRead(model, profile) {
    if (!model.IsMasterDetail) {
        var gridId = "Grid_" + profile.Name;
        var ejGrid = zGrid(gridId);
        var refresh = false;

        var filterSettings = JSON.parse(zLocalStorageGet("$easylob$" + gridId + "_Filter"));
        if (filterSettings) {
            ejGrid.model.filterSettings = filterSettings;
            refresh = true;
        }

        var searchSettings = JSON.parse(zLocalStorageGet("$easylob$" + gridId + "_Search"));
        if (searchSettings) {
            ejGrid.model.searchSettings = searchSettings;
            ejGrid.model.searchSettings.fields = profile.GridSearchProperties;
            $("#" + gridId + "_searchbar").val(searchSettings.key);
            refresh = true;
        }

        if (refresh) {
            ejGrid.refreshContent();
        }
    }
}

function zOnCollectionViewWrite(model, profile, args) {
    if (!model.IsMasterDetail) {
        var gridId = "Grid_" + profile.Name;
        var ejGrid = zGrid(gridId);

        switch (args.requestType) {
            case "filtering":
                zLocalStorageSet("$easylob$" + gridId + "_Filter", JSON.stringify(ejGrid.model.filterSettings));
                break;
            case "searching":
                zLocalStorageSet("$easylob$" + gridId + "_Search", JSON.stringify(ejGrid.model.searchSettings));
                break;
        }
    }
}

function zOnCRUDView(model) {
    var controllerAction = model.ControllerAction ? model.ControllerAction.toLowerCase() : "";
    var isMasterDetail = model.IsMasterDetail ? model.IsMasterDetail : false;
    var customButtonSave = model.CustomButtonSave ? model.CustomButtonSave : false;
    var customButtonOK = model.CustomButtonOK ? model.CustomButtonOK : false;

    $("#Button_Save").hide();
    $("#Button_OK").hide();

    if (controllerAction === "create" || controllerAction === "update" || customButtonSave) {
        $("#Button_Save").show();
    }

    if (isMasterDetail) {
        $("#Button_Save").hide();
    }

    if (controllerAction === "create" || controllerAction === "update" || controllerAction === "delete" || customButtonOK) {
        $("#Button_OK").show();
    }
}

function zOnItemView(model, profile) {
    var controllerAction = model.ControllerAction ? model.ControllerAction.toLowerCase() : "";

    // Read-Only
    var readOnly = controllerAction === "delete" || controllerAction === "read" || model.IsReadOnly;
    $("input.form-control").not(":input[type=button], :input[type=image], :input[type=reset], :input[type=submit]").prop("readonly", readOnly);
    // ReadOnly.js
    // https://github.com/haggen/readonly
    $("select").readonly(readOnly);
    //readonly(parentId + " select", readOnly);
    $("textarea").prop("readonly", readOnly);
    $("input[name*='_Lookup'][type!='checkbox']").prop("readonly", true);
    if (readOnly) {
        $("input[type='checkbox']").prop("disabled", true);

        $("input[data-role='ejdatepicker']").each(function() {
            $(this).data("ejDatePicker").option("readOnly", true);
        });
        $("input[data-role='ejdatetimepicker']").each(function() {
            $(this).data("ejDateTimePicker").option("readOnly", true);
        });

        $("img.z-buttonLookup").hide();
    }
    else {
        $("img.z-buttonLookup").show();
    }

    var i;

    // Hidden
    var hiddenProperties = profile.EditHiddenProperties;
    var hiddenPropertiesLength = hiddenProperties.length;
    for (i = 0; i < hiddenPropertiesLength; i++) {
        $("#Group_" + profile.Name + "_" + hiddenProperties[i]).hide();
    }

    // Read-Only
    var readOnlyProperties = profile.EditReadOnlyProperties;
    var readOnlyPropertiesLength = readOnlyProperties.length;
    for (i = 0; i < readOnlyPropertiesLength; i++) {
        $("#" + profile.Name + "_" + readOnlyProperties[i]).prop("readonly", true);

        $("select#" + profile.Name + "_" + readOnlyProperties[i]).readonly(true);

        $("textarea#" + profile.Name + "_" + readOnlyProperties[i]).prop("readonly", true);

        $("input[type='checkbox'][id='" + profile.Name + "_" + readOnlyProperties[i] + "']").removeProp("readonly");
        $("input[type='checkbox'][id='" + profile.Name + "_" + readOnlyProperties[i] + "']").prop("disabled", true);

        $("input[data-role='ejdatepicker'][id='" + profile.Name + "_" + readOnlyProperties[i] + "']").each(function () {
            $(this).data("ejDatePicker").option("readOnly", true);
        });
        $("input[data-role='ejdatetimepicker'][id='" + profile.Name + "_" + readOnlyProperties[i] + "']").each(function () {
            $(this).data("ejDateTimePicker").option("readOnly", true);
        });

        $("#" + profile.Name + "_" + readOnlyProperties[i] + "_LookupButton").hide();
    }

    var id;

    // Collections (PK)
    var hiddenCollections = profile.EditHiddenCollections;
    var hiddenCollectionsLength = hiddenCollections.length;
    for (i = 0; i < hiddenCollectionsLength; i++) {
        id = "TabSheet_" + profile.Name + "_" + hiddenCollections[i];
        $("a[href='#" + id + "']").css("display", "none");
        $("#" + id).css("display", "none");
    }
    var collections = profile.EditCollections;
    var collectionsLength = collections.length;
    for (i = 0; i < collectionsLength; i++) {
        id = "TabSheet_" + profile.Name + "_" + collections[i];
        if (controllerAction === "create") {
            $("a[href='#" + id + "']").css("display", "none");
            $("#" + id).css("display", "none");
        } else {
            $("a[href='#" + id + "']").removeAttr("display");
            $("#" + id).removeAttr("display");
            //$("a[href='#" + id + "']").css("display", "block");
            //$("#" + id).css("display", "block");
        }
    }
    if (controllerAction == "create") {
        zTabDictionaryWrite(profile.Name, 0);
    }

    // ENTER => TAB
    zEnter2Tab();
    //$("input").keydown(function (e) {
    //    var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
    //    if (key === 13) {
    //        e.preventDefault();
    //        var inputs = $(this).closest("form").find(":input:visible");
    //        inputs.eq(inputs.index(this) + 1).focus();
    //    }
    //});

    // Tab
    var tabIndex = zTabDictionaryRead(profile.Name);
    if (tabIndex && tabIndex >= 0) {
        var ejTab = zTab("Tab_" + profile.Name);
        ejTab.setModel({
            selectedItemIndex: tabIndex
        });
    }

    // <div></div>
    // CRUD.cshtml                  <div id="Form_Entity" style = "display: none;">
    // CRUD.cshtml                      <div>
    // _EntityItem.cshtml                   <div id="Item_Entity">
    $("#Item_" + profile.Name).parent().parent().show();

    zShowOperationResult(model.OperationResult);
}

function zOnLookupView(model, profile, gridId) {
    var ejGrid = zGrid(gridId);

    // Search
    ejGrid.model.searchSettings.fields = profile.GridSearchProperties;

    zShowOperationResult(model.OperationResult);
}

function zOnLookupViewActionBegin(model, args) {
    if (args.requestType == "add" || args.requestType == "beginedit" || args.requestType == "delete") {
        args.cancel = true;
    } else if (args.requestType == "filtering") {
        if (args.currentFilterObject && args.currentFilterObject.length > 0 && args.currentFilterObject[0].operator == "startswith") {
            args.currentFilterObject[0].operator = "contains";
        }
    }
}

function zOnLookupViewRead(model, profile) {
    if (!model.IsMasterDetail) {
        var gridId = model.ValueId + "_LookupGrid";
        var ejGrid = zGrid(gridId);
        var refresh = false;

        var filterSettings = JSON.parse(zLocalStorageGet("$easylob$" + gridId + "_Filter"));
        if (filterSettings) {
            ejGrid.model.filterSettings = filterSettings;
            refresh = true;
        }

        var searchSettings = JSON.parse(zLocalStorageGet("$easylob$" + gridId + "_Search"));
        if (searchSettings) {
            ejGrid.model.searchSettings = searchSettings;
            ejGrid.model.searchSettings.fields = profile.GridSearchProperties;
            $("#" + gridId + "_searchbar").val(searchSettings.key);
            refresh = true;
        }

        if (refresh) {
            ejGrid.refreshContent();
        }
    }
}

function zOnLookupViewWrite(model, profile, args) {
    if (!model.IsMasterDetail) {
        var gridId = model.ValueId + "_LookupGrid";
        var ejGrid = zGrid(gridId);

        switch (args.requestType) {
            case "filtering":
                zLocalStorageSet("$easylob$" + gridId + "_Filter", JSON.stringify(ejGrid.model.filterSettings));
                break;
            case "searching":
                zLocalStorageSet("$easylob$" + gridId + "_Search", JSON.stringify(ejGrid.model.searchSettings));
                break;
        }
    }
}

//// Session Storage - Non-Persistent per TAB

function zSessionStorageClear() {
    window.sessionStorage.clear();
}

function zSessionStorageGet(item) {
    return window.sessionStorage.getItem(item);
}

function zSessionStorageRemove(item) {
    window.sessionStorage.removeItem(item);
}

function zSessionStorageSet(item, data) {
    window.sessionStorage.setItem(item, data);
}

//// Syncfusion

function zGrid(gridId) {
    var ejGrid = $("#" + gridId).data("ejGrid");
    if (!ejGrid) {
        ej.widget.init($("#" + gridId).parent()); // #Grid_Entity => #Collection_Entity
        ejGrid = $("#" + gridId).data("ejGrid");
    }

    return ejGrid;
}

function zGridDataManager(gridId, dataSourceUrl, functionBeforeSend, isRefresh) {
    if ($("#" + gridId).length) {
        if (!isRefresh) {
            isRefresh = false;
        }

        var ejGrid = zGrid(gridId);

        if (!ejGrid.model.dataSource) {
            var customAdaptor = new ej.UrlAdaptor().extend({
                beforeSend: functionBeforeSend
            });
            ejGrid.dataSource(ej.DataManager({
                adaptor: new customAdaptor(),
                url: dataSourceUrl
            }));
        }

        if (isRefresh) {
            ejGrid.refreshContent();
        }
    }
}

function zGridDataSource(gridId, dataSourceUrl, isRefresh) {
    if ($("#" + gridId).length) {
        if (!isRefresh) {
            isRefresh = false;
        }

        var ejGrid = zGrid(gridId);

        if (!ejGrid.model.dataSource) {
            ejGrid.dataSource(ej.DataManager({
                adaptor: new ej.UrlAdaptor(),
                url: dataSourceUrl
            }));
        }

        if (isRefresh) {
            ejGrid.refreshContent();
        }
    }
}

function zLookupElements(data, elements, culture) {
    // ZLibrary.Mvc.LookupModelElement
    // elements.Id
    // elements.Property
    if (elements) {
        var elementsLength = elements.length;
        for (var i = 0, length = elementsLength; i < length; i++) {
            var element = elements[i];
            // $("#Id")
            if ($("#" + element.Id).length) {
                // data.Property
                if (data.hasOwnProperty(element.Property)) {
                    var value = Globalize.format(data[element.Property]);
                    try {
                        data[element.Property].getFullYear(); // Date
                        value = Globalize.format(data[element.Property], "d");
                    } catch (exception) { }
                    $("#" + element.Id).val(value);
                    $("#" + element.Id).change(); // Knockout
                }
            }
        }
    }
}

function zSyncfusionCollection(id) {
    //ej.widget.init($("#" + id));
}

function zSyncfusionCollectionReady(id) {
    //ej.widget.init($("#" + id));
}

function zSyncfusionItem(id) {
    // Validate hidden fields
    $.validator.setDefaults({ ignore: null });
    // Parse validators
    $.validator.unobtrusive.parse($("#ZAjax"));

    //ej.widget.init($("#" + id));
}

function zSyncfusionItemReady(id) {
    //ej.widget.init($("#" + id));
}

function zSyncfusionLookup(id) {
}

function zSyncfusionLookupReady(id) {
}

function zTab(tabId) {
    var ejTab = $("#" + tabId).data("ejTab");
    if (!ejTab) {
        ej.widget.init($("#" + tabId).parent()); // #Tab_Entity => #Item_Entity
        ejTab = $("#" + tabId).data("ejTab");
    }

    return ejTab;
}
