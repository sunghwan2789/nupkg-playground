#!/usr/bin/env bash

targets="x86_64-unknown-linux-gnu aarch64-unknown-linux-gnu x86_64-pc-windows-gnu"

for target in $targets
do
    cargo build --release --target=$target
done
