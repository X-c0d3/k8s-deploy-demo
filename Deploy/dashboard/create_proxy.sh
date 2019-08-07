#!/bin/sh
echo 'Get login token with Remote SSH';
echo '################################################################################';
ssh root@192.168.137.101 'kubectl get secret -n kube-system | grep k8sadmin | cut -d " " -f1 | xargs -n 1 | xargs kubectl get secret  -o 'jsonpath={.data.token}' -n kube-system | base64 --decode';
echo '';
echo '################################################################################';
echo 'Copy token key for login K8S Dashboard';
echo 'http://127.0.0.1:8080/api/v1/namespaces/kube-system/services/https:kubernetes-dashboard:/proxy/#!/login';
open -a /Applications/Chess.app http://127.0.0.1:8080/api/v1/namespaces/kube-system/services/https:kubernetes-dashboard:/proxy/\#\!/login


kubectl --kubeconfig ./admin.conf proxy --port=8080