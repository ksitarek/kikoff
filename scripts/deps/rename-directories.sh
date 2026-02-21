#!/usr/bin/env bash

function rename_directories() {
  echo "Renaming directories..."

  # Rename deepest directories first (reverse depth order) to avoid path breakage
  local dirs
  dirs="$(find "${REPO_ROOT}/src" -type d -name "${OLD_NAME}.*" | awk -F/ '{print NF, $0}' | sort -rn | cut -d' ' -f2-)"

  local dir
  while IFS= read -r dir; do
    [[ -z "${dir}" ]] && continue
    local parent dirname new_dirname new_dir
    parent="$(dirname "${dir}")"
    dirname="$(basename "${dir}")"
    new_dirname="${dirname//${OLD_NAME}/${NEW_NAME}}"
    new_dir="${parent}/${new_dirname}"

    if [[ "${dir}" != "${new_dir}" ]]; then
      mv "${dir}" "${new_dir}"
      echo "  Renamed: ${dirname} -> ${new_dirname}"
    fi
  done <<< "${dirs}"
}
