#!/usr/bin/env bash

function update_modules_json() {
  if [[ ! -f "${MODULES_FILE}" ]]; then
    echo "[]" > "${MODULES_FILE}"
  fi

  local updated
  updated="$(python3 -c "
import json
with open('${MODULES_FILE}') as f:
    modules = json.load(f)
name = '${MODULE_NAME}'
if name not in modules:
    modules.append(name)
    modules.sort()
print(json.dumps(modules, indent=2))
")"
  echo "${updated}" > "${MODULES_FILE}"
  echo "Updated modules.json."
}
