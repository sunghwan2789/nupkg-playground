use std::{ffi::CStr, ffi::CString, os::raw::c_char};

pub struct Handler {
    name: String,
    call_count: u32,
}

// Calling Rust Functions from Other Languages
#[no_mangle]
pub extern "C" fn create_handler() -> *mut Handler {
    let h = Handler {
        name: String::from("init"),
        call_count: 0,
    };
    Box::into_raw(Box::new(h))
}

#[no_mangle]
pub unsafe extern "C" fn set_handler_name(handler: *mut Handler, string: *const c_char) -> () {
    let name = CStr::from_ptr(string);
    (*handler).name = name.to_str().unwrap().to_owned()
}

#[no_mangle]
pub unsafe extern "C" fn get_handler_name(handler: *const Handler) -> *const c_char {
    let s = CString::new(&*(*handler).name).unwrap();
    let p = s.as_ptr();
    std::mem::forget(s);
    p
}

#[no_mangle]
pub unsafe extern "C" fn invoke_handler(handler: *mut Handler) -> u32 {
    (*handler).call_count += 1;
    (*handler).call_count
}

#[no_mangle]
pub unsafe extern "C" fn destroy_handler(handler: *mut Handler) -> () {
    let _ = Box::from_raw(handler);
}
