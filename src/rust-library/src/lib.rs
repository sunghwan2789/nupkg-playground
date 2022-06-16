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
pub unsafe extern "C" fn set_handler_name(handle: *mut Handler, value: *const c_char) -> () {
    let mut handler = &mut *handle;
    let name = CStr::from_ptr(value);
    handler.name = name.to_str().unwrap().to_owned();
}

#[no_mangle]
pub unsafe extern "C" fn get_handler_name(handle: *const Handler) -> *const c_char {
    let handler = &*handle;
    let s = CString::new(handler.name.as_bytes()).unwrap();
    let p = s.as_ptr();
    std::mem::forget(s);
    p
}

#[no_mangle]
pub unsafe extern "C" fn invoke_handler(handle: *mut Handler) -> u32 {
    let mut handler = &mut *handle;
    handler.call_count += 1;
    handler.call_count
}

#[no_mangle]
pub unsafe extern "C" fn destroy_handler(handle: *mut Handler) -> () {
    let _ = Box::from_raw(handle);
}
