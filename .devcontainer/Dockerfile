FROM mcr.microsoft.com/dotnet/sdk:8.0

ARG USERNAME=myuser
ARG USER_UID=1000
ARG USER_GID=$USER_UID
ARG USER_SHELL=/bin/bash

# Create the user
RUN groupadd --gid $USER_GID $USERNAME \
    && useradd --uid $USER_UID --gid $USER_GID -m $USERNAME \
    && apt-get update \
    && apt-get install -y sudo \
    && echo $USERNAME ALL=\(root\) NOPASSWD:ALL > /etc/sudoers.d/$USERNAME \
    && chmod 0440 /etc/sudoers.d/$USERNAME \
    && usermod -s $USER_SHELL $USERNAME

RUN apt-get update

# some important utilities
RUN apt-get install -y openssh-client tree
    
# switch to user $USERNAME
SHELL ["/bin/bash", "-c"]
USER $USERNAME