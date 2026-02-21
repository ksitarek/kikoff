#!/usr/bin/env bash

function verify_build() {
  local slnx_file
  slnx_file="$(find "${REPO_ROOT}" -maxdepth 1 -name '*.slnx' -type f | head -n 1)"

  if [[ -z "${slnx_file}" ]]; then
    echo "Error: No .slnx file found for build verification." >&2
    exit 1
  fi

  echo "Running clean build..."
  if dotnet build "${slnx_file}" --no-incremental 2>&1; then
    echo "Build succeeded."
  else
    echo "Error: Build failed." >&2
    exit 1
  fi
}
