#!/usr/bin/env bash

pushd src/rust-library
./build.sh
popd

pushd src/wrapper
./pack.sh
popd
