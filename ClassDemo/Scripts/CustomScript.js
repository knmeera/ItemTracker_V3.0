function myFunction() {
    document.getElementById("myForm").reset();
}
  

$(function () {
    $("#AssignedDate,#ItemEndDate,#ResolvedDate").datepicker({
        dateFormat: "mm-dd-yy ",
        altField: "#datepicker-4",
        altFormat: "hh:m"
    });
});