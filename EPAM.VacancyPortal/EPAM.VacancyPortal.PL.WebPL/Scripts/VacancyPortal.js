function verifyAdmin(id) {
    $.post("/Pages/RequestHandlers/AdminRequests.cshtml", { type: 'verifyAdmin', id: id },
        function () {
            $("#cand-list").empty();
            $("#cand-list").load("/Pages/Partial/Admin/Candidates.cshtml");
        });
}

function deleteAdmin(id) {
    $.post("/Pages/RequestHandlers/AdminRequests.cshtml", { type: 'deleteAdmin', id: id },
        function () {
            $("#admins-list").empty();
            $("#admins-list").load("/Pages/Partial/Admin/Admins.cshtml");
        });
}

