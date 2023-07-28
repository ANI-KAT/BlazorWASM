window.ShowAlert = (type, message) => {
    if (type == "success") {
        Swal.fire(
            'Success Notification!',
            'Success',
            'success'
        )
    }
    else {
        Swal.fire(
            'Failure Notification!',
            message,
            'error'
        )
    }
}