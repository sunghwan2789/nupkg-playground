FROM mcr.microsoft.com/dotnet/sdk:6.0

RUN curl https://sh.rustup.rs -sSf | sh -s -- -y -t \
        x86_64-pc-windows-gnu \
        x86_64-unknown-linux-gnu \
        aarch64-unknown-linux-gnu \
    && apt update && apt install -y \
        gcc-mingw-w64-x86-64-win32 \
        gcc-x86-64-linux-gnu \
        gcc-aarch64-linux-gnu

ENV PATH="/root/.cargo/bin:${PATH}"
