
function Validation()
{
    debugger
    var ItemIdVal = $("#ItemId").val();
    var categoryVal = $("#ItemCategoryId").val();
    var priorityVal = $("#ItemPriorityId").val();
    var projectVal = $("#ItemProjectId").val();
    var itemTypeVal = $("#ItemTypeId").val();
    var itemStatusVal = $("#ItemStatusId").val();
    //var summaryVal = $("ItemSummary").val();
    var CreatedByVal = $("#CreatedBy").val();
    //var CreatedDateVal = $("#ItemCreatedDate").val();
    var ParentVal = $("#Parent").val();
    var AssignedToVal = $("#AssignedTo").val();
    var AssignedDateVal = $("#AssignedDate").val();
    var ItemEndDateVal = $("#ItemEndDate").val();
    var OwnerVal = $("#Owner").val();
    var workCompletedVal = $("#workCompleted").val();
    var ResolvedDateVal = $("#ResolvedDate").val();
    //var ImpactVal = $("#Impact").val();
    //var ResolutionVal = $("#Resolution").val();


    var ItemIdvalid = ifNullOrEmpty("ItemId", ItemIdVal, "itIDerr") && IsNumber("ItemId", ItemIdVal, "itIDerr");
    var categoryValid = ifNullOrEmpty("ItemCategoryId", categoryVal, "cat");
    var priorityValid = ifNullOrEmpty("ItemPriorityId", priorityVal, "prio");
    var projectnameValid = ifNullOrEmpty("ItemProjectId", projectVal, "PN") /*&& charVAL("ItemProjectId", projectVal, "PN");*/
    var itemTypeValid = ifNullOrEmpty("ItemTypeId", itemTypeVal, "itmty");
    var itemStatusValid = ifNullOrEmpty("ItemStatusId", itemStatusVal, "status");
    var CreatedByValid = ifNullOrEmpty("CreatedBy", CreatedByVal, "creBy") && charVAL("CreatedBy", CreatedByVal, "creBy");
    var ParentValid = IsNumber("ItemId", ParentVal, "paId");
    var AssignedToValid = ifNullOrEmpty("AssignedTo", AssignedToVal, "assTo") && charVAL("AssignedTo", AssignedToVal, "assTo");
    var AssignedDateValid = ifNullOrEmpty("AssignedDate", AssignedDateVal, "assDate");
    var ItemEndDateValid = ifNullOrEmpty("ItemEndDate", ItemEndDateVal, "endDate") && DateValidation("ItemEndDate", AssignedDateVal, ItemEndDateVal,"endDate");
    var OwnerValid = ifNullOrEmpty("Owner",OwnerVal, "own") && charVAL("Owner",OwnerVal, "own");
    var workCompletedValid = IsNumber("workCompleted", workCompletedVal, "WC");
    var ResolvedDateValid = ifNullOrEmpty("ResolvedDate", ResolvedDateVal, "resoDate") && DateValidation("ResolvedDate", AssignedDateVal, ResolvedDateVal, "resoDate");


    if (ItemIdvalid && categoryValid && priorityVal && projectnameValid && itemStatusValid && CreatedByValid && ParentValid && AssignedToValid && AssignedDateValid && ItemEndDateValid && OwnerValid && workCompletedValid && ResolvedDateValid)
    {
    return true;
    }
    else 
    return false;

};
function ifNullOrEmpty(fieldId, fieldIdValue, fieldErrMess) {
    
    if (fieldIdValue == "" || fieldIdValue == null) {
        $("#" + fieldErrMess).text("field can't be null/empty");
        $("#" + fieldId).css("border", "1px solid red");
        $("#" + fieldErrMess).css("color", "red");
    return false;
}
    else 
        $("#" + fieldId).css("border", "1px solid black");
        $("#" + fieldErrMess).text("");
    return true;
    
};

function IsNumber(fieldId, fieldIdVal, fieldErrMess) {
    
    if (!/^[0-9]+$/.test(fieldIdVal)){
        $("#" + fieldErrMess).text("ID Should be a number"); 
        $("#" + fieldId).css("border", "1px solid red");
        $("#" + fieldErrMess).css("color", "red");
return false;
}
    else 
    $("#" + fieldErrMess).text("");
    $("#" + fieldId).css("color", "black");
    $("#" + fieldId).css("border", "1px thin black");
return true;
};

function charVAL(fieldId,fieldIdVal, fieldErrMess) {
    
    if (!/^[ A-Za-z0-9_.-]*$/.test(fieldIdVal)) {
        $("#" + fieldErrMess).text("invalid spl charecters");
        $("#" + fieldErrMess).css("color", "red");
        $("#" + fieldId).css("border", "1px solid red");
        return false
    }
    else
    $("#" + fieldErrMess).text("");
    $("#" + fieldId).css("color", "black");
    $("#" + fieldId).css("border", "1px solid black");
        return true;
};
function DateValidation(DateAfterId, DateBefore, DateAfter, errmsg) {
    if (new Date(DateBefore) <= new Date(DateAfter))
        return true;
    else {
        $("#" + errmsg).text("this date cannot be greater than assigned date");
        $("#" + DateAfterId).css("border", "1px solid red");
        $("#" + errmsg).css("color", "red");
        return false;
    }
};