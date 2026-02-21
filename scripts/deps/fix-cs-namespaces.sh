#!/usr/bin/env bash

function fix_cs_namespaces() {
  echo "Fixing namespaces in .cs files..."

  local cs_files
  cs_files="$(find "${REPO_ROOT}/src" -name "*.cs" -type f 2>/dev/null | sort)"

  if [[ -z "${cs_files}" ]]; then
    echo "  No .cs files found, skipping."
    return
  fi

  local cs_file
  local count=0
  while IFS= read -r cs_file; do
    [[ -z "${cs_file}" ]] && continue
    if grep -q "${OLD_NAME}" "${cs_file}" 2>/dev/null; then
      sed -i '' "s/${OLD_NAME}/${NEW_NAME}/g" "${cs_file}"
      local rel_path="${cs_file#"${REPO_ROOT}"/}"
      echo "  Updated: ${rel_path}"
      count=$((count + 1))
    fi
  done <<< "${cs_files}"

  echo "  Updated namespaces in ${count} file(s)."
}
