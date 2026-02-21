#!/usr/bin/env bash

function rename_csproj_files() {
  echo "Renaming .csproj files..."

  local csproj_files
  csproj_files="$(find "${REPO_ROOT}/src" -name "*.csproj" -type f | sort)"

  local csproj
  while IFS= read -r csproj; do
    [[ -z "${csproj}" ]] && continue
    local dir filename new_filename
    dir="$(dirname "${csproj}")"
    filename="$(basename "${csproj}")"
    new_filename="${filename//${OLD_NAME}/${NEW_NAME}}"

    if [[ "${filename}" != "${new_filename}" ]]; then
      mv "${csproj}" "${dir}/${new_filename}"
      echo "  Renamed: ${filename} -> ${new_filename}"
    fi
  done <<< "${csproj_files}"
}
