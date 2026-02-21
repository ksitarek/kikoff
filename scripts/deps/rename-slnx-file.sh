#!/usr/bin/env bash

function rename_slnx_file() {
  echo "Renaming .slnx file..."

  local old_slnx="${REPO_ROOT}/${OLD_NAME}.slnx"
  local new_slnx="${REPO_ROOT}/${NEW_NAME}.slnx"

  if [[ ! -f "${old_slnx}" ]]; then
    echo "  Warning: ${OLD_NAME}.slnx not found, skipping." >&2
    return
  fi

  if [[ "${old_slnx}" != "${new_slnx}" ]]; then
    mv "${old_slnx}" "${new_slnx}"
    echo "  Renamed: ${OLD_NAME}.slnx -> ${NEW_NAME}.slnx"
  fi
}
